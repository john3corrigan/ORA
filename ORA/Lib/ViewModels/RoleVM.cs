using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class RoleVM {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<AssignmentVM> Assignments { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
