using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class ProfileVM
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PositionVM Position { get; set; }
        public int PositionID { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public int? EducationID { get; set; }
        public EducationVM Education { get; set; }
        public string Industry { get; set; }
        public string Summary { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CreateProfileVM
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PositionVM Position { get; set; }
        public List<PositionVM> PositionList { get; set; }
        public int PositionID { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public int EducationID { get; set; }
        public EducationVM Education { get; set; }
        public List<EducationVM> EducationList { get; set; }
        public string NewEducation { get; set; }
        public string Industry { get; set; }
        public string Summary { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
