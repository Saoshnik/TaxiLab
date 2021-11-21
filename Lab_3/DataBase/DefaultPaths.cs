using System;

namespace Lab_3.DataBase
{
    static class DefaultPaths // как через конфиги
    {
        public static string TAXISFROMXMLPATH { get; } = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\TaxiFromXml.xml";
        public static string PREMIUMENGINESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\PremiumEngines.xml";
        public static string BUDGETENGINESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\BudgetEngines.xml";
        public static string PREMIUMBODIESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\PremiumBodies.xml";
        public static string BUDGETBODIESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\BudgetBodies.xml";
    }
}
