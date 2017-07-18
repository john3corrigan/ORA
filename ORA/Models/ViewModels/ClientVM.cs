using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels {
    public class ClientVM {
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string ClientAbbreviation { get; set; }
        public MetadataVM Metadata { get; set; }
    }
}
