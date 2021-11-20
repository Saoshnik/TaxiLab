using System.Linq;
using System.Collections.Generic;
using Lab_3.InterfaceImplementers;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.InterfaceImplementers.Parts.Bodies;
using Lab_3.InterfaceImplementers.Parts;

namespace Lab_3.DataBase
{
    // c обработкой nullReferenceEx
    class DataProcessor
    {
        // Engines и PremiumEngines, BudgetEngines содержат разные экзмплеры
        public static List<Taxi> Taxis { get; private set; }
        public static List<TaxiFromXml> TaxisFromXml { get; private set; }

        #region mbDelete
        public static List<Engine> Engines { get; private set; }
        public static List<Body> Bodies { get; private set; }
        #endregion // end mbDelete

        public static List<Engine> PremiumEngines { get; set; }
        public static List<Engine> BudgetEngines { get; private set; }
        public static List<Body> PremiumBodies { get; private set; }
        public static List<Body> BudgetBodies { get; private set; }

        public DataProcessor() { }
        static DataProcessor()
        {
            TaxisFromXml = Serializer.Deserialize(DefaultPaths.TAXISFROMXMLPATH, TaxisFromXml);
            PremiumEngines = ProcessEngines(Serializer.Deserialize(DefaultPaths.PREMIUMENGINESPATH, PremiumEngines));
            BudgetEngines = ProcessEngines(Serializer.Deserialize(DefaultPaths.BUDGETENGINESPATH, BudgetEngines));
            PremiumBodies = ProcessBodies(Serializer.Deserialize(DefaultPaths.PREMIUMBODIESPATH, PremiumBodies));
            BudgetBodies = ProcessBodies(Serializer.Deserialize(DefaultPaths.BUDGETBODIESPATH, BudgetBodies));

            Engines.AddRange(PremiumEngines);
            Engines.AddRange(BudgetEngines);
            Bodies.AddRange(PremiumBodies);
            Bodies.AddRange(BudgetBodies);

            List<Part> parts = new List<Part>();
            parts.AddRange(Engines);
            parts.AddRange(Bodies);

            Taxis = MakeTaxis(TaxisFromXml, parts);
        }

        // переделать под Type type; type.GetFields() + check:рефлексия
        public static List<Engine> ProcessEngines(List<Engine> list)
        {
            // как проверить id?
            var processList = new List<Engine>(list);
            if (processList == null) return new List<Engine>();
            foreach (var item in processList)
            {
                if (item == null) processList.Remove(item);
                item.Cost = item?.Cost ?? 0;
                item.Copyrights = item?.Copyrights ?? "нет данных";
                item.FuelConsumption = item?.FuelConsumption ?? 0;
                item.Speed = item?.Speed ?? 0;
            }
            return processList;
        }
        public static List<Body> ProcessBodies(List<Body> list)
        {
            // как проверить id?
            var processList = new List<Body>(list);
            if (processList == null) return new List<Body>();
            foreach (var item in processList)
            {
                if (item == null) processList.Remove(item);
                item.Cost = item?.Cost ?? 0;
                item.Number = item?.Number ?? $"нет данных";
                item.Seats = item?.Seats ?? 0;
            }
            return processList;
        }
        // private, пользователь не должен работать со служебным классом TaxiFromXml
        private static List<TaxiFromXml> ProcessTaxisFromXml(List<TaxiFromXml> list) 
        {
            var processList = new List<TaxiFromXml>(list);
            if (processList == null) return new List<TaxiFromXml>();
            foreach (var item in processList)
            {
                if (item == null) processList.Remove(item);
                item.EngineId = item?.EngineId ?? int.MaxValue;
                item.BodyId = item?.BodyId ?? int.MaxValue;
                item.TaxiId = item?.TaxiId ?? int.MaxValue;
                if (item.EngineId == int.MaxValue && item.BodyId == int.MaxValue && item.TaxiId == int.MaxValue) processList.Remove(item);
            }
            return processList;
        }

        public static List<Engine> GetProcessEngines(string path) { return ProcessEngines(Serializer.Deserialize(path, new List<Engine>())); }
        public static List<Body> GetProcessBodies(string path) { return ProcessBodies(Serializer.Deserialize(path, new List<Body>())); }
        public static List<Taxi> GetTaxis(string path) {
            List<Part> parts = new List<Part>();
            parts.AddRange(GetProcessEngines(path)); 
            parts.AddRange(GetProcessBodies(path));
            // Десериализация -> Обработка -> Сборка
            return MakeTaxis(ProcessTaxisFromXml(Serializer.Deserialize(path, new List<TaxiFromXml>())), parts);
        }

        // сборка taxi, если не работает, можно попробовать внести данные в xml о том какого типа Premium or Budget там находится
        /* private, пользователь работает с GetTaxis */
        private static List<Taxi> MakeTaxis(List<TaxiFromXml> taxisFromXml, List<Part> parts)
        {
            var taxis = new List<Taxi>();
            foreach (var taxiFromXml in taxisFromXml)
            {
                var taxi = new Taxi();
                foreach (var part in parts)
                {
                    if ((part as Engine) != null && taxiFromXml.EngineId == part.Id) taxi.Parts.Add(part);
                    else if((part as Body) != null && taxiFromXml.BodyId == part.Id) taxi.Parts.Add(part);   
                }
                if (taxi.Parts.Any()) { taxi.SetId(taxiFromXml.TaxiId); taxis.Add(taxi); }
            }
            return taxis;
        }
    }
}
