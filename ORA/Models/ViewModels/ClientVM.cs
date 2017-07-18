using System.Collections.Generic;

namespace Lib.ViewModels {
    public class ClientVM {
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string ClientAbbreviation { get; set; }
        public List<AssignmentVM> Assignments { get; set; }
        public List<StoryVM> Stories { get; set; }
        public List<ProjectVM> Projects { get; set; }
        public List<TeamVM> Teams { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
