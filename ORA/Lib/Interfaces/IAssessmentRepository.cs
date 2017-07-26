using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IAssessmentRepository {
        AssessmentVM GetAssessmentByID(int id);
        List<AssessmentVM> GetAllAssessments();
        void AddAssessment(AssessmentVM assessment);
        void UpdateAssessment(AssessmentVM assessment);
        void DeleteAssessment(int id);
    }
}
