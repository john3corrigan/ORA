using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class ProjectVM {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public int ProjectNumber { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public List<KPIVM> KPI { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
