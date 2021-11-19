using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.DataBase
{
    [Serializable]
    public class TaxiFromXml
    {
        public int EngineId { get; set; }
        public int BodyId { get; set; }
        public int TaxiId { get; set; }
    }
}