using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    public class Employee {
        [Key]
        public int EmployeeID { get; set; }
        public string Title { get; set; }

        [Required]
        public string EmployeeNumber { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        public byte[] Salt { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeFirstName { get; set; }

        [StringLength(1)]
        public string EmployeeMI { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeLastName { get; set; }

        public bool ActiveFlag { get; set; }

        public int ProfileID { get; set; }
        public Profile Profile { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
