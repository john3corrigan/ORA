using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels {
    public class AssessmentVM {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        [Display(Name ="Problem Solving")]
        public int TDProblemSolving { get; set; }
        [Display(Name = "Quality Of Work")]
        public int TDQualityOfWork { get; set; }
        [Display(Name = "TDProductivity")]
        public int TDProductivity { get; set; }
        [Display(Name = "Product Knowledge")]
        public int TDProductKnowledge { get; set; }
        [Display(Name = "Comments")]
        public string TDComments { get; set; }
        [Display(Name = "Professionalism/TeamWork")]
        public int CSRProfessionalismTeamwork { get; set; }
        [Display(Name = "Verbal Skills")]
        public int CSRVerbalSkills { get; set; }
        [Display(Name = "Written Skills")]
        public int CSRWrittenSkills { get; set; }
        [Display(Name = "Listening Skills")]
        public int CSRListeningSkills { get; set; }
        [Display(Name = "Comments")]
        public string CSRComments { get; set; }
        [Display(Name = "Attendence")]
        public int ADAttendence { get; set; }
        [Display(Name = "Ethic Behavior")]
        public int ADEthiclBehavior { get; set; }
        [Display(Name = "Ability to Meet Deadlines")]
        public int ADMeetsDeadlines { get; set; }
        [Display(Name = "Organise Detailed Work")]
        public int ADOrganizeDetailedWork { get; set; }
        [Display(Name = "Comments")]
        public string ADComments { get; set; }
        [Display(Name = "Resource Use")]
        public int TMResourceUse { get; set; }
        [Display(Name = "Feedback")]
        public int TMFeedBack { get; set; }
        [Display(Name = "Technical Monitoring")]
        public int TMTechnicalMonitoring { get; set; }
        [Display(Name = "Asking Questions")]
        public int TMAskingQuestions { get; set; }
        [Display(Name = "Comments")]
        public string TMComments { get; set; }
        [Display(Name = "Attitude At/About Work")]
        public int MIAttitudeWork { get; set; }
        [Display(Name = "Grooming/Appearence")]
        public int MIGroomingAppearence { get; set; }
        [Display(Name = "Personal Growth")]
        public int MIPersonalGrowth { get; set; }
        [Display(Name = "Potencial Advancement")]
        public int MIPotencialAdvancement { get; set; }
        [Display(Name = "Comments")]
        public string MIComments { get; set; }
        public bool ActiveFlag { get; set; }
        public int AssignmentID { get; set; }
        public AssignmentVM Assignment { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class CreateAssessmentVM
    {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Problem Solving")]
        public int TDProblemSolving { get; set; }
        [Display(Name = "Quality Of Work")]
        public int TDQualityOfWork { get; set; }
        [Display(Name = "TDProductivity")]
        public int TDProductivity { get; set; }
        [Display(Name = "Product Knowledge")]
        public int TDProductKnowledge { get; set; }
        [Display(Name = "Comments")]
        public string TDComments { get; set; }
        [Display(Name = "Professionalism/TeamWork")]
        public int CSRProfessionalismTeamwork { get; set; }
        [Display(Name = "Verbal Skills")]
        public int CSRVerbalSkills { get; set; }
        [Display(Name = "Written Skills")]
        public int CSRWrittenSkills { get; set; }
        [Display(Name = "Listening Skills")]
        public int CSRListeningSkills { get; set; }
        [Display(Name = "Comments")]
        public string CSRComments { get; set; }
        [Display(Name = "Attendence")]
        public int ADAttendence { get; set; }
        [Display(Name = "Ethic Behavior")]
        public int ADEthiclBehavior { get; set; }
        [Display(Name = "Ability to Meet Deadlines")]
        public int ADMeetsDeadlines { get; set; }
        [Display(Name = "Organise Detailed Work")]
        public int ADOrganizeDetailedWork { get; set; }
        [Display(Name = "Comments")]
        public string ADComments { get; set; }
        [Display(Name = "Resource Use")]
        public int TMResourceUse { get; set; }
        [Display(Name = "Feedback")]
        public int TMFeedBack { get; set; }
        [Display(Name = "Technical Monitoring")]
        public int TMTechnicalMonitoring { get; set; }
        [Display(Name = "Asking Questions")]
        public int TMAskingQuestions { get; set; }
        [Display(Name = "Comments")]
        public string TMComments { get; set; }
        [Display(Name = "Attitude At/About Work")]
        public int MIAttitudeWork { get; set; }
        [Display(Name = "Grooming/Appearence")]
        public int MIGroomingAppearence { get; set; }
        [Display(Name = "Personal Growth")]
        public int MIPersonalGrowth { get; set; }
        [Display(Name = "Potencial Advancement")]
        public int MIPotencialAdvancement { get; set; }
        [Display(Name = "Comments")]
        public string MIComments { get; set; }
        public bool ActiveFlag { get; set; }
        public int AssignmentID { get; set; }
        public List<EmployeeVM> EmployeeList { get; set; }
        public AssignmentVM Assignment { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
