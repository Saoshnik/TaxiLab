using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Interfaces
{
    interface IBody : IPart
    {
        int Seats { get; set; }
        string Number { get; set; }
        
        string Doors();
    }
}
