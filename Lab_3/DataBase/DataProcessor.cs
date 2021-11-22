using System.Linq;
using System.Collections.Generic;
using Lab_3.InterfaceImplementers;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.InterfaceImplementers.Parts.Bodies;
using Lab_3.InterfaceImplementers.Parts;

namespace Lab_3.DataBase
{
    // c об работкой nullReferenceEx
    static class DataProcessor
    {
        public static List<TaxiFromXml> TaxisFromXml { get; set; } = new List<TaxiFromXml>();

        public static List<Engine> PremiumEngines { get; set; } = new List<Engine>();
        public static List<Engine> BudgetEngines { get; set; } = new List<Engine>();
        public static List<Body> PremiumBodies { get; set; } = new List<Body>();
        public static List<Body> BudgetBodies { get; set; } = new List<Body>();

        public static List<Taxi> Taxis { get; set; }

        static DataProcessor()
        {
            var taxisFromXml = new List<TaxiFromXml>();
            var premiumEngines = new List<PremiumEngine>();
            var budgetEngines = new List<BudgetEngine>();
            var premiumBodies = new List<PremiumBody>();
            var budgetBodies = new List<BudgetBody>();

            Serializer.Deserialize(DefaultPaths.TAXISFROMXMLPATH, ref taxisFromXml);
            Serializer.Deserialize(DefaultPaths.PREMIUMENGINESPATH, ref premiumEngines);
            Serializer.Deserialize(DefaultPaths.BUDGETENGINESPATH, ref budgetEngines);
            Serializer.Deserialize(DefaultPaths.PREMIUMBODIESPATH, ref premiumBodies);
            Serializer.Deserialize(DefaultPaths.BUDGETBODIESPATH, ref budgetBodies);

            foreach (var item in premiumEngines) PremiumEngines.Add(item);
            foreach (var item in budgetEngines) BudgetEngines.Add(item);
            foreach (var item in premiumBodies) PremiumBodies.Add(item);
            foreach (var item in budgetBodies) BudgetBodies.Add(item);

            TaxisFromXml = ProcessTaxisFromXml(taxisFromXml);
            PremiumEngines = ProcessEngines(PremiumEngines);
            BudgetEngines = ProcessEngines(BudgetEngines);
            PremiumBodies = ProcessBodies(PremiumBodies);
            BudgetBodies = ProcessBodies(BudgetBodies);

            // how to use List<T>.AddRange() here
            Taxis = MakeTaxis(TaxisFromXml, new List<Part>(PremiumEngines).Concat(BudgetEngines).Concat(PremiumBodies).Concat(BudgetBodies).ToList());
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

        // сборка taxi, если не работает, можно попробовать внести данные в xml о том какого типа Premium or Budget там находится
        /* private, пользователь работает с GetTaxis */
        private static List<Taxi> MakeTaxis(List<TaxiFromXml> taxisFromXml, List<Part> parts)
        {
            var taxis = new List<Taxi>();
            foreach (var taxiFromXml in taxisFromXml)
            {
                var taxi = new Taxi();
                taxi.Parts = new List<Part>(); // почему без этой записи Exception ??
                foreach (var part in parts)
                {
                    if ((part as Engine) != null && taxiFromXml.EngineId == part.Id) taxi.Parts.Add(part);
                    else if ((part as Body) != null && taxiFromXml.BodyId == part.Id) taxi.Parts.Add(part);
                }
                if (taxi.Parts.Any()) { taxi.SetId(taxiFromXml.TaxiId); taxis.Add(taxi); }
            }
            return taxis;
        }

        // переделать под Type type; type.GetFields() + check:рефлексия
        public static List<Taxi> GetTaxis(string path)
        {
            var engines = new List<Engine>();
            var bodies = new List<Body>();

            Serializer.Deserialize(path, ref engines);
            Serializer.Deserialize(path, ref bodies);

            List<Part> parts = new List<Part>();
            parts.AddRange(engines);
            parts.AddRange(bodies);
            // Десериализация -> Обработка -> Сборка
            return MakeTaxis(ProcessTaxisFromXml(Serializer.Deserialize<List<TaxiFromXml>>(path)), parts);
        }
    }
}
