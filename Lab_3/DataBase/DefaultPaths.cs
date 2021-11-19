using System;

namespace Lab_3.DataBase
{
    static class DefaultPaths // как через конфиги
    {
        public static readonly string TAXISFROMXMLPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\TaxisFromXml.xml";
        public static readonly string PREMIUMENGINESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\PremiumEngines.xml";
        public static readonly string BUDGETENGINESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\BudgetEngines.xml";
        public static readonly string PREMIUMBODIESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\PremiumBodies.xml";
        public static readonly string BUDGETBODIESPATH = $"{Environment.CurrentDirectory}\\DataBase\\Xml\\Parts\\BudgetBodies.xml";
    }
}
