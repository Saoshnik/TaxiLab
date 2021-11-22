using System;

namespace Lab_3.InterfaceImplementers.Parts.Bodies
{
    [Serializable]
    public class BudgetBody : Body
    {
        public BudgetBody() { }
        public BudgetBody(BudgetBody body) : base(body) { }

        public override string Doors() { return $"Tu-Duf!"; }
    }
}
