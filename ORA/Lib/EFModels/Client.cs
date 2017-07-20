﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lib.EFModels {
    public class Client {
        [Key]
        public int ClientID { get; set; }
        public string Title { get; set; }

        [StringLength(30)]
        public string ClientName { get; set; }

        [StringLength(5)]
        public string ClientAbbreviation { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}