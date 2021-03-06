﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    public class Project {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [Required]
        public int ProjectNumber { get; set; }

        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }

        public int? ClientID { get; set; }
        //public virtual Client Client { get; set; }

        public virtual ICollection<KPI> KPI { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
