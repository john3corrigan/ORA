using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;

namespace Lib.InterfacesLogic
{
    public interface IAssessmentLogic
    {
        AssessmentVM GetAssessmentByAssessmentID(int assessmentID);
        List<AssessmentVM> GetAllAssessments();
        void CreateAssessment(AssessmentVM assessment);
        void UpdateAssessment(AssessmentVM updatedAssessment);
    }
}
