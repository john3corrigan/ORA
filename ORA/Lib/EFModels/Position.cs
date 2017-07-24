using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Lib.EFModels {
    public class Position {
        public int PositionID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
