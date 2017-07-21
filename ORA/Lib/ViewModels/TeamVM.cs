using System.Collections.Generic;

namespace Lib.ViewModels {
    public class TeamVM {
        public int TeamID { get; set; }
        public string Title { get; set; }
        public string TeamName { get; set; }
        public List<AssignmentVM> Assignments { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public int MetadataID { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
