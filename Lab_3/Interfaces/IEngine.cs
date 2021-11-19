using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Interfaces
{
    interface IEngine : IPart
    {
        double FuelConsumption { get; set; }
        string Copyrights { get; set; }
        int Speed { get; set; }

        string Move();
    }
}