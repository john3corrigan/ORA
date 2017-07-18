using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class ProjectVM {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public int ProjectNumber { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
