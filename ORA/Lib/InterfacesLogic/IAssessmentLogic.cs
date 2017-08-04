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
        AssessmentVM GetAssessmentByID(int assessmentID);
        List<AssessmentVM> GetAllAssessments();
        void AddAssessment(CreateAssessmentVM assessment, int teamID);
        void UpdateAssessment(AssessmentVM updatedAssessment);
        CreateAssessmentVM AddAssessment(DateTime created, int myID, int teamID);
    }
}
