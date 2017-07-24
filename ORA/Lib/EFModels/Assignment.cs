using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lib.EFModels {
    public class Assignment {
        [Key]
        public int AssignmentID { get; set; }
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int ClientID { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public virtual Employee Employee { get; set; }

        [Required]
        public int PositionID { get; set; }

        [Required]
        public virtual Position Position { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [Required]
        public int TeamID { get; set; }

        [Required]
        public virtual Team Team { get; set; }

        [Required]
        public virtual ICollection<KPI> KPIS { get; set; }

        [Required]
        public virtual ICollection<Assessment> Assessments { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
