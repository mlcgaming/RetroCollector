﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class Company : IndexItem {
        private string name;

        public string Name {
            get { return name; }
        }

        public Company(int id, string name) {
            this.id = id;
            this.name = name;
        }
    }
}
