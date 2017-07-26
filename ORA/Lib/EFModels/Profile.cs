using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.EFModels {
    public class Profile {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public int PositionID { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public List<string> Education { get; set; }
        public string Industry { get; set; }
        public string Summary { get; set; }
    }
}
