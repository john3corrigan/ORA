using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Assignment {
        [Key]
        public int AssignmentID { get; set; }
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("ClientID")]
        public int ClientID { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        [ForeignKey("PositionID")]
        public int PositionID { get; set; }

        [ForeignKey("RoleID")]
        public int RoleID { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
