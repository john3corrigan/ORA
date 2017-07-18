using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class EmployeeVM {
        public int EmployessID { get; set; }
        public string Title { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMI { get; set; }
        public string EmployeeLastName { get; set; }
        public bool ActiveFlag { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
