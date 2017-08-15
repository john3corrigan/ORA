using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    public class KPI {
        [Key]
        public int KPIID { get; set; }
        public int Points { get; set; }
        public int TCCreated { get; set; }
        public int TCExcuted { get; set; }
        public int TCFailed { get; set; }
        public int TCPassed { get; set; }
        public int DefectsFound { get; set; }
        public int DefectsFixed { get; set; }
        public int DefectsAccepted { get; set; }
        public int DefectsRejected { get; set; }
        public int DefectsDeferred { get; set; }
        public int CriticalDefects { get; set; }
        public int TestHrsPlanned { get; set; }
        public int TestHrsActual { get; set; }
        public int BugsFoundProduction { get; set; }
        public int TotalHrsFixingBugs { get; set; }

        public int? AssignmentID { get; set; }
        //public virtual Assignment Assignment { get; set; }

        public int? ProjectID { get; set; }
        //public virtual Project Project { get; set; }

        public int? SprintID { get; set; }
        //public virtual Sprint Sprint { get; set; }

        public int? StoryID { get; set; }
        //public virtual Story Story { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
