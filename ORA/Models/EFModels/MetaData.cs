using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    [Table("Metadata")]
    public class Metadata {
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //public int _OldID { get; set; }
        //public string ContentType { get; set; }
        //public string AppCreatedBy { get; set; }
        //public string AppModifiedBy { get; set; }
        //public string WorkflowInstanceID { get; set; }
        //public string FileType { get; set; }
        //public string URLPath { get; set; }
        //public string Path { get; set; }
        //public string ItemType { get; set; }
        //public string EncodedAbsoluteURL { get; set; }
    }
}
