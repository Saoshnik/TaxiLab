using System;
using Lab_3.Interfaces;
using Lab_3.InterfaceImplementers.Parts.Engines;
using Lab_3.InterfaceImplementers.Parts.Bodies;

namespace Lab_3.InterfaceImplementers.Parts
{
    [Serializable]
    public abstract class Part : IPart, IHaveInfo
    {
        public Part() { }
        public Part(Part part) { Id = part.Id; Cost = part.Cost; }

        public int Cost { get; set; }
        public int Id { get; set; }

        public new string ToString() 
        {
            string tmp = string.Empty;
            if ((this as Engine) != null) tmp += $"{((Engine)this).ToString()}";
            else if ((this as Body) != null) tmp += $"{((Body)this).ToString()}";
            return $"--- {GetType().Name} ---\nPartID: {Id}\nPartCost: {Cost}\n{tmp}"; 
        } // new or override
    }
}
