using System.Collections.Generic;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.InterfaceImplementers.Parts.Bodies;
using Lab_3.Interfaces;
using Lab_3.InterfaceImplementers.Parts;

namespace Lab_3.InterfaceImplementers
{
    class Taxi : ITaxi
    {
        // нужен ли метод Add
        public List<Part> Parts { get; set; }
        public int Cost { get { int temp = 0; foreach (var item in Parts) temp += item.Cost; return temp; } }
        public int Id { get; private set; }
        public void SetId(int id) { Id = id; }

        public new string ToString()
        {
            var temp = string.Empty;
            foreach (var item in Parts)
            {
                var part = string.Empty;
                if ((item as Engine) != null) { part = item.ToString(); }
                else if ((item as Body) != null) { part = item.ToString(); }

                if (part != null) temp = $"TaxiCost: {Cost}\n{part}";
            }
            return temp;
        }
    }
}