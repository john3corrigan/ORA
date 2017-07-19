using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
