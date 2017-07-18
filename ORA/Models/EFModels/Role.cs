using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Role {
        [Key]
        public int RoleID { get; set; }
        public string Title { get; set; }

        [StringLength(30)]
        public string RoleName { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
