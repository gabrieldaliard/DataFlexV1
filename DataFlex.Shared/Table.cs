﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataFlex.Shared
{
    public class Table
    { 
        public int id { get; set; }
    public string Description { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool IsNull { get; set; }
        public bool IsUniqueKey { get; set; }
    }
}
