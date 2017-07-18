using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class RoleVM {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
