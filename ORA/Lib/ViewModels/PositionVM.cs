using System.Collections.Generic;

namespace Lib.ViewModels {
    public class PositionVM {
        public int PositionID { get; set; }
        public string Title { get; set; }
        public List<AssignmentVM> Assignments { get; set; }
        public int MetadataID { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
