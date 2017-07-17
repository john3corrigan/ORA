using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Project {
        [Key]
        public int ProjectID { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [Required]
        public int ProjectNumber { get; set; }

        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
