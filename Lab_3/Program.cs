using System;
using System.Collections.Generic;
using Lab_3.InterfaceImplementers.Parts.Bodies;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.DataBase;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxiFromXml> tmp1 = new();
            List<PremiumEngine> tmp2 = new();
            List<BudgetEngine> tmp3 = new();
            List<PremiumBody> tmp4 = new();
            List<BudgetBody> tmp5 = new();



            //Serializer.Deserialize(DefaultPaths.TAXISFROMXMLPATH, ref tmp1);
            //Serializer.Deserialize(DefaultPaths.PREMIUMENGINESPATH, ref tmp2);
            //var value = Serializer.Deserialize<List<BudgetEngine>>(DefaultPaths.BUDGETENGINESPATH);
            //Serializer.Deserialize(DefaultPaths.PREMIUMBODIESPATH, ref tmp4);
            //Serializer.Deserialize(DefaultPaths.BUDGETBODIESPATH, ref tmp5);



            foreach (var item in DataProcessor.Taxis) Console.WriteLine($"{item.ToString()}");
            Console.WriteLine();
        }
    }
}


