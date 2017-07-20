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

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public int PositionID { get; set; }
        public virtual Position Position { get; set; }

        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<KPI> KPIS { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
