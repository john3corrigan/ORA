using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels {
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Employee Badge Number")]
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Employee Middle Initial")]
        public string EmployeeMI { get; set; }
        [Display(Name = "Employee Last Name")]
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
    public class CreateEmployeeVM
    {
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Employee Badge Number")]
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Employee Middle Initial")]
        public string EmployeeMI { get; set; }
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }
        public string Email { get; set; }
        public bool ActiveFlag { get; set; }
        public int ProfileID { get; set; }
        public ProfileVM Profile { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public int PositionID { get; set; }
        public List<PositionVM> Position { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
