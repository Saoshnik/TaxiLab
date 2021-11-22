using System;
using Lab_3.Interfaces;

namespace Lab_3.InterfaceImplementers.Parts.Bodies
{
    [Serializable]
    public abstract class Body : Part, IBody
    {
        public Body() { }
        public Body(Body body) { Seats = body.Seats; Number = body.Number; }

        public int Seats { get; set; }
        public string Number { get; set; }

        public abstract string Doors();
        public new string ToString() { return $"Number: {Number}\nSeats: {Seats}\n"; }
    }
}
