using System.Collections.Generic;

namespace Lib.ViewModels {
    public class RoleVM {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<AssignmentVM> Assignments { get; set; }
        public int MetadataID { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
