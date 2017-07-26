using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    public class Sprint {
        [Key]
        public int SprintID { get; set; }

        public string Title { get; set; }
        [Required]
        public int SprintNumber { get; set; }

        [Required]
        public string SprintName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<KPI> KPI { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
