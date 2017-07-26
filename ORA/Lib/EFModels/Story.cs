using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lib.EFModels {
    public class Story {
        [Key]
        public int StoryID { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string StoryName { get; set; }

        [Required]
        public int StoryNumber { get; set; }

        [Required]
        public DateTime StoryStartDate { get; set; }

        [Required]
        public DateTime StoryEndDate { get; set; }

        [Required]
        public int ClientID { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public virtual ICollection<KPI> KPI { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
