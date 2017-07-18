﻿using System;
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

        public virtual ICollection<KPI> KPIs { get; set; }

        public int MetadatID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
