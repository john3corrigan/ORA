using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces
{
    public interface IEducationRepository
    {
        List<EducationVM> GetAllEducation();
        EducationVM GetEducationByID(int id);
        void AddEducation(EducationVM Education);
        void UpdateEducation(EducationVM Education);
    }
}
