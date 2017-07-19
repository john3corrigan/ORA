namespace Lib.ViewModels {
    public class AssessmentVM {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        public int TDProblemSolving { get; set; }
        public int TDQualityOfWork { get; set; }
        public int TDProductivity { get; set; }
        public int TDProductKnowledge { get; set; }
        public string TDComments { get; set; }
        public int CSRProfessionalismTeamwork { get; set; }
        public int CSRVerbalSkills { get; set; }
        public int CSRWrittenSkills { get; set; }
        public int CSRListeningSkills { get; set; }
        public string CSRComments { get; set; }
        public int ADAttendence { get; set; }
        public int ADEthiclBehavior { get; set; }
        public int ADMeetsDeadlines { get; set; }
        public int ADOrganizeDetailedWork { get; set; }
        public string ADComments { get; set; }
        public int TMResourceUse { get; set; }
        public int TMFeedBack { get; set; }
        public int TMTehcnicalMonitoring { get; set; }
        public int TMAskingQuestions { get; set; }
        public string TMComments { get; set; }
        public int MIAttitudeWork { get; set; }
        public int MIGroomingAppearence { get; set; }
        public int MIPersonalGrowth { get; set; }
        public int MIPotencialAdvancement { get; set; }
        public string MIComments { get; set; }
        public bool ActiveFlag { get; set; }
        public int AssignmentID { get; set; }
        public AssignmentVM Assignment { get; set; }
        public int MetadataID { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
