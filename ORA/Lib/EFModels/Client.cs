using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace Lib.EFModels {
    public class Client {
        [Key]
        public int ClientID { get; set; }
        public string Title { get; set; }

        [StringLength(30)]
        public string ClientName { get; set; }

        [StringLength(5)]
        public string ClientAbbreviation { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }

        public virtual ICollection<Story> Story { get; set; }

        public virtual ICollection<Project> Project { get; set; }

        public virtual ICollection<Team> Team { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
