using System;
using System.Collections.Generic;
using Lab_3.InterfaceImplementers;
using Lab_3.DataBase;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Taxi> otherTaxis = new List<Taxi>();
            otherTaxis = DataProcessor.Taxis;
            foreach (var item in otherTaxis) item.ToString();


            List<Taxi> taxis = new List<Taxi>(DataProcessor.Taxis);
            foreach (var item in taxis) item.ToString();
        }
    }
}


