using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Employee {
        [Key]
        public int EmployeeID { get; set; }
        public string Title { get; set; }

        [Required]
        public string EmployeeNumber { get; set; }

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

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
