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
        public List<KPIVM> KPIs { get; set; }
        public int MetadataID { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
