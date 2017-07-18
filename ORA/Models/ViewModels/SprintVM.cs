using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class SprintVM {
        public int SprintID { get; set; }
        public string Title { get; set; }
        public int SprintNumber { get; set; }
        public string SprintName { get; set; }
        public ClientVM Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
