using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
