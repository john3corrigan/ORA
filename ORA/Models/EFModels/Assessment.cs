using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string TDComments { get; set; }

        [Required]
        public int CSRProfessionalismTeamwork { get; set; }

        [Required]
        public int CSRVerbalSkills { get; set; }

        [Required]
        public int CSRWrittenSkills { get; set; }

        [Required]
        public int CSRListeningSkills { get; set; }

        public string CSRComments { get; set; }

        [Required]
        public int ADAttendence { get; set; }

        [Required]
        public int ADEthiclBehavior { get; set; }

        [Required]
        public int ADMeetsDeadlines { get; set; }

        [Required]
        public int ADOrganizeDetailedWork { get; set; }

        public string ADComments { get; set; }

        [Required]
        public int TMResourceUse { get; set; }

        [Required]
        public int TMFeedBack { get; set; }

        [Required]
        public int TMTehcnicalMonitoring { get; set; }

        [Required]
        public int TMAskingQuestions { get; set; }

        public string TMComments { get; set; }

        [Required]
        public int MIAttitudeWork { get; set; }

        [Required]
        public int MIGroomingAppearence { get; set; }

        [Required]
        public int MIPersonalGrowth { get; set; }

        [Required]
        public int MIPotencialAdvancement { get; set; }

        public string MIComments { get; set; }

        [ForeignKey("AssignmentID")]
        public Assignment Assignment { get; set; }

        [ForeignKey("MetadataID")]
        public Metadata Metadata { get; set; }
    }
}
