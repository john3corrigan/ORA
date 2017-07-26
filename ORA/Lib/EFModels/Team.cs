using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace Lib.EFModels {
    public class Team {
        [Key]
        public int TeamID { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
