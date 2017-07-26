using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels {
    public class AssessmentVM {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        [Display(Name = "'TD' Problem Solving")]
        public int TDProblemSolving { get; set; }
        [Display(Name = "'TD' Quality Of Work")]
        public int TDQualityOfWork { get; set; }
        [Display(Name = "'TD' Productivity")]
        public int TDProductivity { get; set; }
        [Display(Name = "'TD' Product Knoledge")]
        public int TDProductKnowledge { get; set; }
        [Display(Name = "'TD' Comments")]
        public string TDComments { get; set; }
        [Display(Name = "'CSR' Professionalism/TeamWork")]
        public int CSRProfessionalismTeamwork { get; set; }
        [Display(Name = "'CSR' Verbal Skills")]
        public int CSRVerbalSkills { get; set; }
        [Display(Name = "'CSR' Written Skills")]
        public int CSRWrittenSkills { get; set; }
        [Display(Name = "'CSR' Listening Skills")]
        public int CSRListeningSkills { get; set; }
        [Display(Name = "'CSR' Comments")]
        public string CSRComments { get; set; }
        [Display(Name = "'AD' Attendence")]
        public int ADAttendence { get; set; }
        [Display(Name = "'AD' Ethic Behavior")]
        public int ADEthiclBehavior { get; set; }
        [Display(Name = "'AD' Meets Deadlines")]
        public int ADMeetsDeadlines { get; set; }
        [Display(Name = "'AD' Organize Detailed Work")]
        public int ADOrganizeDetailedWork { get; set; }
        [Display(Name = "'AD' Comments")]
        public string ADComments { get; set; }
        [Display(Name = "'TM' Resource Use")]
        public int TMResourceUse { get; set; }
        [Display(Name = "'TM' Feedback")]
        public int TMFeedBack { get; set; }
        [Display(Name = "'TM' Technical Monitoring")]
        public int TMTehcnicalMonitoring { get; set; }
        [Display(Name = "'TM' Asking Questions")]
        public int TMAskingQuestions { get; set; }
        [Display(Name = "'TM' Comments")]
        public string TMComments { get; set; }
        [Display(Name = "'MI' Attitude at Work")]
        public int MIAttitudeWork { get; set; }
        [Display(Name = "'MI' Grooming/Appearance")]
        public int MIGroomingAppearence { get; set; }
        [Display(Name = "'MI' Personal Growth")]
        public int MIPersonalGrowth { get; set; }
        [Display(Name = "'MI' Potencial Advancement")]
        public int MIPotencialAdvancement { get; set; }
        [Display(Name = "'MI' Comments")]
        public string MIComments { get; set; }
        public bool ActiveFlag { get; set; }
        public int AssignmentID { get; set; }
        public AssignmentVM Assignment { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
