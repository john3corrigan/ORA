using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Lib.EFModels {
    public class Role {
        [Key]
        public int RoleID { get; set; }
        public string Title { get; set; }

        [StringLength(30)]
        public string RoleName { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
