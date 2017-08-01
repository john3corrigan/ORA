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

        public int? EmployeeID { get; set; }

        public int? PositionID { get; set; }

        public int? RoleID { get; set; }

        public int? TeamID { get; set; }

        public virtual ICollection<KPI> KPI { get; set; }

        public virtual ICollection<Assessment> Assessment { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
