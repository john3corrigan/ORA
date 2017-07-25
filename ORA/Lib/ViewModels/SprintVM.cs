using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class SprintVM {
        public int SprintID { get; set; }
        public string Title { get; set; }
        public int SprintNumber { get; set; }
        public string SprintName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<KPIVM> KPI { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
