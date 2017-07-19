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

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<KPI> KPIs { get; set; }

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
