using System.Collections.Generic;
using System;

namespace Lib.ViewModels {
    public class PositionVM {
        public int PositionID { get; set; }
        public string Title { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
