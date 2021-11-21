using System;
using Lab_3.Interfaces;

namespace Lab_3.InterfaceImplementers.Parts.Engines
{
    [Serializable]
    public abstract class Engine : Part, IEngine
    {
        public double FuelConsumption { get; set; }
        public string Copyrights { get; set; }
        public int Speed { get; set; }

        public abstract string Move();
        public new string ToString() { return $"{base.ToString()}Copyrights: {Copyrights}\nSpeed: {Speed}\nFuelConsumption: {FuelConsumption}"; }
    }
}
