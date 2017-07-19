using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.EFModels {
    public class Position {
        public int PositionID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public int MetadataID { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
