using System.Collections.Generic;
using System;

namespace Lib.ViewModels {
    public class EmployeeVM {
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMI { get; set; }
        public string EmployeeLastName { get; set; }
        public string Email { get; set; }
        public bool ActiveFlag { get; set; }
        public int ProfileID { get; set; }
        public ProfileVM Profile { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
