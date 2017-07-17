using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class TeamVM {
        public int TeamID { get; set; }
        public string Title { get; set; }
        public string TeamName { get; set; }
        public ClientVM Client { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
