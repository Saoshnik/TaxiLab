using System;
using Lab_3.Interfaces;

namespace Lab_3.InterfaceImplementers.Parts.Bodies
{
    [Serializable]
    abstract class Body : Part, IBody
    {
        public int Seats { get; set; }
        public string Number { get; set; }

        public abstract string Doors();
        public new string ToString() { return $"{base.ToString()}Number: {Number}\nSeats: {Seats}"; }
    }
}
