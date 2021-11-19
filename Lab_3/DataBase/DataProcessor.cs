using System.Collections.Generic;
using Lab_3.InterfaceImplementers;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.InterfaceImplementers.Parts.Bodies; 

namespace Lab_3.DataBase
{
    class DataProcessor
    {
        // Engines и PremiumEngines, BudgetEngines содержат разные экзмплеры
        public static List<Taxi> Taxis { get; private set; }
        public static List<TaxiFromXml> TaxisFromXml { get; private set; }

        public static List<Engine> Engines { get; private set; }
        public static List<Body> Bodies { get; private set; }

        public static List<Engine> PremiumEngines { get; set; }
        public static List<Engine> BudgetEngines { get; private set; }
        public static List<Body> PremiumBodies { get; private set; }
        public static List<Body> BudgetBodies { get; private set; }

        public DataProcessor() { }
        static DataProcessor() // частичная обработка nullReferenceEx
        {
            TaxisFromXml = Serializer.Deserialize(DefaultPaths.TAXISFROMXMLPATH, TaxisFromXml);
            PremiumEngines = ProcessEngines(Serializer.Deserialize(DefaultPaths.PREMIUMENGINESPATH, PremiumEngines));
            BudgetEngines = ProcessEngines(Serializer.Deserialize(DefaultPaths.BUDGETENGINESPATH, BudgetEngines));
            PremiumBodies = ProcessBodies(Serializer.Deserialize(DefaultPaths.PREMIUMBODIESPATH, PremiumBodies));
            BudgetBodies = ProcessBodies(Serializer.Deserialize(DefaultPaths.BUDGETBODIESPATH, BudgetBodies));

            foreach (var item in PremiumEngines) Engines.Add(item);
            foreach (var item in BudgetEngines) Engines.Add(item);
            foreach (var item in PremiumBodies) Bodies.Add(item);
            foreach (var item in BudgetBodies) Bodies.Add(item);

            foreach (var taxiFromXml in TaxisFromXml)
            {
                var engine = GetEngine(taxiFromXml.EngineId);
                var body = GetBody(taxiFromXml.BodyId);

                // сборка taxi, если не работает, можно попробовать внести данные в xml о том какого типа Premium or Budget там находится
                var taxi = new Taxi();
                taxi.SetId(taxiFromXml.TaxiId);
                taxi.Parts.Add(engine);
                taxi.Parts.Add(body);
                Taxis.Add(taxi);
            }
        }

        // возвращаю объекты абстактного класса??
        private static Engine GetEngine(int EngineId)
        {
            foreach (var item in Engines) { if (item.Id == EngineId) return item; }
            return null;
        }
        private static Body GetBody(int BodyId)
        {
            foreach (var item in Bodies) { if (item.Id == BodyId) return item; }
            return null;
        }

        // id пропустил
        public static List<Engine> ProcessEngines(List<Engine> list)
        {
            List<Engine> processList = new List<Engine>(list);
            if (processList == null) return new List<Engine>();
            foreach (var item in list)
            {
                if (item == null) list.Remove(item);
                item.Cost = item?.Cost ?? 0;
                item.Copyrights = item?.Copyrights ?? "нет данных";
                item.FuelConsumption = item?.FuelConsumption ?? 0;
                item.Speed = item?.Speed ?? 0;
            }
            return processList;
        }
        public static List<Body> ProcessBodies(List<Body> list)
        {
            List<Body> processList = new List<Body>(list);
            if (processList == null) return new List<Body>();
            foreach (var item in list)
            {
                if (item == null) list.Remove(item);
                item.Cost = item?.Cost ?? 0;
                item.Number = item?.Number ?? $"нет данных";
                item.Seats = item?.Seats ?? 0;
            }
            return processList;
        }
    }
}
