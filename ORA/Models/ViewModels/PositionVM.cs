﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class PositionVM {
        public int PositionID { get; set; }
        public string Title { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}