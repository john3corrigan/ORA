using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class KPIVM {
        public int KPIID { get; set; }
        public string EmployeeName { get; set; }
        public int Points { get; set; }
        public int TCCreated { get; set; }
        public int TCExcuted { get; set; }
        public int TCFailed { get; set; }
        public int TCPassed { get; set; }
        public int DefectsFound { get; set; }
        public int DefectsFixed { get; set; }
        public int DefectsAccepted { get; set; }
        public int DefectsRejected { get; set; }
        public int DefectsDeferred { get; set; }
        public int CriticalDefects { get; set; }
        public int TestHrsPlanned { get; set; }
        public int TestHrsActual { get; set; }
        public int BugsFoundProduction { get; set; }
        public int TotalHrsFixingBugs { get; set; }
        public int AssignmentID { get; set; }
        public AssignmentVM Assignment { get; set; }
        public int ProjectID { get; set; }
        public ProjectVM Project { get; set; }
        public int SprintID { get; set; }
        public SprintVM Sprint { get; set; }
        public int StoryID { get; set; }
        public StoryVM Story { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class CreateKPIVM{
        public int KPIID { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }
        public int TCCreated { get; set; }
        public int TCExcuted { get; set; }
        public int TCFailed { get; set; }
        public int TCPassed { get; set; }
        public int DefectsFound { get; set; }
        public int DefectsFixed { get; set; }
        public int DefectsAccepted { get; set; }
        public int DefectsRejected { get; set; }
        public int DefectsDeferred { get; set; }
        public int CriticalDefects { get; set; }
        public int TestHrsPlanned { get; set; }
        public int TestHrsActual { get; set; }
        public int BugsFoundProduction { get; set; }
        public int TotalHrsFixingBugs { get; set; }
        public int AssignmentID { get; set; }
        public AssignmentVM Assignment { get; set; }
        public List<AssignmentVM> AssignmentList { get; set; }
        public int ProjectID { get; set; }
        public ProjectVM Project { get; set; }
        public List<ProjectVM> ProjectList { get; set; }
        public int SprintID { get; set; }
        public SprintVM Sprint { get; set; }
        public List<SprintVM> SprintList { get; set; }
        public int StoryID { get; set; }
        public StoryVM Story { get; set; }
        public List<StoryVM> StoryList { get; set; }
        public List<TeamVM> TeamList { get; set; }
        public List<ClientVM> ClientList { get; set; }
        public List<EmployeeVM> EmployeeList { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
