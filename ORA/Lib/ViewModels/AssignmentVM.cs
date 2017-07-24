using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class AssignmentVM {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public int EmployeeID { get; set; }
        public EmployeeVM Employee { get; set; }
        public int PositionID { get; set; }
        public PositionVM Position { get; set; }
        public int RoleID { get; set; }
        public RoleVM Role { get; set; }
        public int TeamID { get; set; }
        public TeamVM Team { get; set; }
        public List<KPIVM> KPIS { get; set; }
        public List<AssessmentVM> Assessments { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
