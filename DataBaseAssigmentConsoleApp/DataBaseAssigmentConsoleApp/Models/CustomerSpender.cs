﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Models
{
       public readonly record struct CustomerSpending(int CustomerId, decimal TotalAmountSpent);

}
