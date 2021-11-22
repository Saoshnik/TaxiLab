using System;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    public class PremiumEngine : Engine
    {
        public PremiumEngine() { }
        public PremiumEngine(PremiumEngine engine) : base(engine) { }

        public override string Move() { return $"mrrmrrmrr ＼(=^‥^)/’`"; }
    }
}
