﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Interfaces
{
    interface IPart : IHaveInfo
    {
        int Cost { get; set; }
    }
}