using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    public class PremiumEngine : Engine
    {
        public PremiumEngine() { }
        public PremiumEngine(Engine part) : base(part) { }

        public override string Move() { return $"mrrmrrmrr ＼(=^‥^)/’`"; }
    }
}
