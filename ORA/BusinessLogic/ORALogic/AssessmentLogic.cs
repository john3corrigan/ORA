using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class AssessmentLogic
    {
        private IAssessmentRepository Assessments;

        public AssessmentLogic(IAssessmentRepository assess)
        {
            Assessments = assess;
        }

        public void CreateAssessment(AssessmentVM assessment)
        {
            throw new NotImplementedException();
        }

        public AssessmentVM GetAssessmentByAssessmentID(int assessmentID)
        {
            throw new NotImplementedException();
        }

        public List<AssessmentVM> GetAllAssessments()
        {
            throw new NotImplementedException();
        }

        public void UpdateAssessment(AssessmentVM updatedAssessment)
        {
            throw new NotImplementedException();
        }
    }
}
