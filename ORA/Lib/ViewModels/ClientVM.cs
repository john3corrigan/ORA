using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels {
    public class ClientVM {
        public int ClientID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Client Abbreviation")]
        public string ClientAbbreviation { get; set; }
        public List<StoryVM> Story { get; set; }
        public List<ProjectVM> Project { get; set; }
        public List<TeamVM> Team { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
