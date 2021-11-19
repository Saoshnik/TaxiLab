using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    class PremiumEngine : Part
    {
        public PremiumEngine() { }
        public PremiumEngine(Part part) { Id = part.Id; Cost = part.Cost; }

        public double FuelConsumption { get; set; }
        public string Copyrights { get; set; }
        public int Speed { get; set; }

        public string Move() { return $"mrrmrrmrr ＼(=^‥^)/’`"; }
    }
}
