using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class KPIVM {
        public int KPIID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
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
        public AssignmentVM Assignment { get; set; }
        public ProjectVM Project { get; set; }
        public SprintVM Sprint { get; set; }
        public StoryVM Story { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
