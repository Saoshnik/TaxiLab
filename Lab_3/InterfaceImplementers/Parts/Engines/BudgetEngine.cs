using System;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    public class BudgetEngine : Engine
    {
        public BudgetEngine() { }
        public BudgetEngine(BudgetEngine engine) : base(engine) { }

        public override string Move() { return $"Brrbrrrbrrrr"; }
    }
}
