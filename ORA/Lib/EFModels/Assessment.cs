using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Lib.EFModels {
    public class Assessment {
        [Key]
        public int AssessmentID { get; set; }
        public string Title { get; set; }

        [Required]
        public int TDProblemSolving { get; set; }

        [Required]
        public int TDQualityOfWork { get; set; }

        [Required]
        public int TDProductivity { get; set; }

        [Required]
        public int TDProductKnowledge { get; set; }

        [StringLength(1000)]
        public string TDComments { get; set; }

        [Required]
        public int CSRProfessionalismTeamwork { get; set; }

        [Required]
        public int CSRVerbalSkills { get; set; }

        [Required]
        public int CSRWrittenSkills { get; set; }

        [Required]
        public int CSRListeningSkills { get; set; }

        [StringLength(1000)]
        public string CSRComments { get; set; }

        [Required]
        public int ADAttendence { get; set; }

        [Required]
        public int ADEthiclBehavior { get; set; }

        [Required]
        public int ADMeetsDeadlines { get; set; }

        [Required]
        public int ADOrganizeDetailedWork { get; set; }

        [StringLength(1000)]
        public string ADComments { get; set; }

        [Required]
        public int TMResourceUse { get; set; }

        [Required]
        public int TMFeedBack { get; set; }

        [Required]
        public int TMTechnicalMonitoring { get; set; }

        [Required]
        public int TMAskingQuestions { get; set; }

        [StringLength(1000)]
        public string TMComments { get; set; }

        [Required]
        public int MIAttitudeWork { get; set; }

        [Required]
        public int MIGroomingAppearence { get; set; }

        [Required]
        public int MIPersonalGrowth { get; set; }

        [Required]
        public int MIPotencialAdvancement { get; set; }

        [StringLength(1000)]
        public string MIComments { get; set; }

        public bool ActiveFlag { get; set; }

        public int? AssignmentID { get; set; }
        //public virtual Assignment Assignment { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
