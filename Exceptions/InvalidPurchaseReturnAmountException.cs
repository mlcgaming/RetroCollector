﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector {
    public class InvalidPurchaseReturnAmountException : Exception {
        public InvalidPurchaseReturnAmountException() : base("Amount returned invalid for purchase") {  }
    }
}
