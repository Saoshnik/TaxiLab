using System;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    public class BudgetEngine : Part
    {
        public BudgetEngine() { }
        public BudgetEngine(Part part) : base(part) { }

        public double FuelConsumption { get; set; }
        public string Copyrights { get; set; }
        public int Speed { get; set; }

        public string Move() { return $"Brrbrrrbrrrr"; }
    }
}
