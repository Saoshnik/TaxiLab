using System.Collections.Generic;
using Lab_3.InterfaceImplementers.Parts;


namespace Lab_3.Interfaces
{
    interface ITaxi : IHaveInfo
    {
        List<Part> Parts { get; set; }
        int Cost { get; }
    }
}
