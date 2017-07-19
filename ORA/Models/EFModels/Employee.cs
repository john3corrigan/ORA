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

        public virtual ICollection<Assignment> Assignments { get; set; }

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
