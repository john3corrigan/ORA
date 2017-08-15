using System;
using System.Collections.Generic;

namespace Lib.ViewModels {
    public class TeamVM {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class CreateTeamVM{
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<AssignmentVM> Assignment { get; set; }
        public int ClientID { get; set; }
        public ClientVM Client { get; set; }
        public List<ClientVM> ClientList { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
