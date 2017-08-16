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
        List<AssessmentVM> GetAssessmentByEmployeeID(int employee);
        List<AssessmentVM> GetAllAssessments();
        void AddAssessment(CreateAssessmentVM assessment);
        void UpdateAssessment(AssessmentVM updatedAssessment);
        CreateAssessmentVM AddAssessment(DateTime created, int myID);
        List<AssessmentVM> GetAssessmentByAssignmentID(int assignmentID);
        List<EmployeeVM> GetAssessmentForServiceManager(int employeeID, DateTime Start, DateTime End);
        List<EmployeeVM> GetAssessmentForTeamLead(int employeeID, DateTime Start, DateTime End);
        string GetAverage(int empID);
    }
}
