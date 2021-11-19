using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.InterfaceImplementers.Parts.Bodies
{
    [Serializable]
    class PremiumBody : Part
    {
        public PremiumBody() { }
        public PremiumBody(Part part) : base(part) { }

        public string Number { get; set; }
        public int Seats { get; set; }

        public string Doors() { return $"tuf"; }
    }
}
