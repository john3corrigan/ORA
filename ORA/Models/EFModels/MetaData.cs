using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    [Table("Metadata")]
    public class Metadata {
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
