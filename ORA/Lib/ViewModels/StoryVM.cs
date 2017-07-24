using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class StoryVM {
        public int StoryID { get; set; }
        public string Title { get; set; }
        public string StoryName { get; set; }
        public int StoryNumber { get; set; }
        public DateTime StoryStartDate { get; set; }
        public DateTime StoryEndDate { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
