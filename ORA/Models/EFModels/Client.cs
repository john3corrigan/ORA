using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Client {
        [Key]
        public int ClientID { get; set; }
        public string Title { get; set; }

        [StringLength(30)]
        public string ClientName { get; set; }

        [StringLength(5)]
        public string ClientAbbreviation { get; set; }

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
