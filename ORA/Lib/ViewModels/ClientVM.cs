using System.Collections.Generic;
using System;

namespace Lib.ViewModels {
    public class ClientVM {
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string ClientAbbreviation { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public List<StoryVM> Storie { get; set; }
        public List<ProjectVM> Project { get; set; }
        public List<TeamVM> Team { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
