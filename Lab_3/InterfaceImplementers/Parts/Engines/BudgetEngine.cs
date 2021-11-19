using System;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    class BudgetEngine : Part
    {
        public BudgetEngine() { }
        public BudgetEngine(Part part) { Id = part.Id; Cost = part.Cost; }

        public double FuelConsumption { get; set; }
        public string Copyrights { get; set; }
        public int Speed { get; set; }

        public string Move() { return $"Brrbrrrbrrrr"; }
    }
}
