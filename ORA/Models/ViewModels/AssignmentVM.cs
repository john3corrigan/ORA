using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class AssignmentVM {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ClientVM Client { get; set; }
        public EmployeeVM EMployee { get; set; }
        public PositionVM Position { get; set; }
        public RoleVM Role { get; set; }
        public TeamVM Team { get; set; }
        public List<KPIVM> KPIS { get; set; }
        public List<AssessmentVM> Assessments { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
