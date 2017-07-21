using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lib.EFModels {
    public class Team {
        [Key]
        public int TeamID { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public int MetadataID { get; set; }
        public Metadata Metadata { get; set; }
    }
}
