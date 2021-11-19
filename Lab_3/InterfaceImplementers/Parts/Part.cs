﻿using System;
using Lab_3.Interfaces;

namespace Lab_3.InterfaceImplementers.Parts
{
    [Serializable]
    abstract class Part : IPart, IHaveInfo
    {
        public Part() { }
        public Part(Part part) { Id = part.Id; Cost = part.Cost; }

        public int Cost { get; set; }
        public int Id { get; protected set; }

        public new string ToString() { return $"{GetType().Name}\nCost: {Cost}"; } // new or override
    }
}