using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class KPILogic : IKPILogic
    {
        private IKPIRepository KPIs;
        private IAssignmentRepository Assignment;
        private IProjectRepository Project;
        private ISprintRepository Sprint;
        private IStoryRepository Story;
        private IEmployeeRepository Employee;
        private IClientRepository Client;

        public KPILogic(IKPIRepository kpi, 
            IAssignmentRepository assign, 
            IProjectRepository prjct, 
            ISprintRepository sprnt,
            IStoryRepository stry,
            IEmployeeRepository mply,
            IClientRepository clnt)
        {
            KPIs = kpi;
            Assignment = assign;
            Project = prjct;
            Sprint = sprnt;
            Story = stry;
            Employee = mply;
            Client = clnt;
        }

        public KPIVM GetKPIByID(int Id)
        {
            return KPIs.GetKPIByID(Id);
        }

        public List<KPIVM> GetKPIBySprintID(int SprintID)
        {
            return KPIs.GetAllKPIs().Where(k => k.SprintID == SprintID).ToList();
        }

        public List<KPIVM> GetKPIByAssignmentID(int AssignmentID)
        {
            return KPIs.GetAllKPIs().Where(k => k.AssignmentID == AssignmentID).ToList();
        }

        public CreateKPIVM GetCreateKPIByID(int Id)
        {
            CreateKPIVM create = KPIs.GetCreateKPIByID(Id);
            create.AssignmentList = Assignment.GetAllAssignments();
            create.ProjectList = Project.GetAllProjects();
            create.SprintList = Sprint.GetAllSprints();
            create.StoryList = Story.GetAllStories();
            return create;
        }

        public List<KPIVM> GetAllKPIs()
        {
            return KPIs.GetAllKPIs();
        }

        public List<KPIVM> GetMyKPIs(int ID)
        {
            List<AssignmentVM> assignment = Employee.GetEmployeeByID(ID).Assignment.Where(k => k.EmployeeID == ID).ToList(); //Grabs a list of Assignments equal to my id
            
            List<KPIVM> KPI = KPIs.GetAllKPIs().Where(k =>
            {
                foreach (var kpi in assignment)
                {//Takes the number of those assignments and converts them into numbers
                    if (kpi.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return KPI;
        }

        public List<KPIVM> GetKPIByDate()
        {
            return KPIs.GetKPIByDate();
        }

        public List<KPIVM> GetKPIsForManager(int empID)
        {
            var myAssignments = Employee.GetEmployeeByID(empID).Assignment.Where(a => a.RoleID < 6);
            var clientAssignments = Assignment.GetAllAssignments().Where(a =>
            {
                foreach (var assign in myAssignments)
                {
                    if (assign.TeamID == a.TeamID || assign.ClientID == a.ClientID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return KPIs.GetAllKPIs().Where(k => {
                foreach (var assign in clientAssignments)
                {
                    if (assign.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
        }

        public List<KPIVM> GetKPIsForLead(int empID)
        {
            var myAssignments = Assignment.GetAllAssignments().Where(a => a.EmployeeID == empID && a.RoleID < 7);
            var teamAssignments = Assignment.GetAllAssignments().Where(a =>
            {
                foreach (var assign in myAssignments)
                {
                    if (assign.TeamID == a.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return KPIs.GetAllKPIs().Where(k => {
                foreach (var assign in teamAssignments)
                {
                    if (assign.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
        }

        public void UpdateKPI(KPIVM updatedKPI)
        {
            KPIs.UpdateKPI(updatedKPI);
        }

        public CreateKPIVM AddKPI(DateTime created)
        {
            CreateKPIVM create = new CreateKPIVM() {
                AssignmentList = GetAssignmentsByDate(created),
                ProjectList = Project.GetAllProjects().Where(a => a.ProjectStartDate < created && a.ProjectEndDate > created).ToList(),
                SprintList = Sprint.GetAllSprints().Where(a => a.StartDate < created && a.EndDate > created).ToList(),
                StoryList = Story.GetAllStories().Where(a => a.StoryStartDate < created && a.StoryEndDate > created).ToList()
            };
            return create;
        }
        public void AddKPI(CreateKPIVM newKPI)
        {
            KPIs.AddKPI(newKPI);
        }

        private List<AssignmentVM> GetAssignmentsByDate(DateTime created)
        {
            List<AssignmentVM> AssignmentList = Assignment.GetAllAssignments().Where(a => a.StartDate < created && a.EndDate > created).ToList();
            foreach(AssignmentVM assign in AssignmentList)
            {
                assign.Employee = Employee.GetEmployeeByID(assign.EmployeeID);
                assign.Client = Client.GetClientByID(assign.ClientID);
            }
            return AssignmentList;
        }

        public List<KPIVM> GetIndividualKPIs(DateTime startDate, DateTime endDate)
        {
            var assignment = Assignment.GetAllAssignments().Where(a => (startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)).ToList();
            var kpi = KPIs.GetAllKPIs().Where(k => {
                foreach (AssignmentVM assign in assignment)
                {
                    if(assign.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return GetEmployeeName(kpi).OrderBy(k => k.EmployeeName).ToList();
        }

        public List<KPIVM> GetTeamsKPIs(DateTime startDate, DateTime endDate, int teamID)
        {
            var assignment = Assignment.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && teamID == a.TeamID).ToList();
            var kpi = KPIs.GetAllKPIs().Where(k => {
                foreach (AssignmentVM assign in assignment)
                {
                    if (assign.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return GetEmployeeName(kpi).OrderBy(k => k.EmployeeName).ToList();
        }

        public List<KPIVM> GetClientKPIs(DateTime startDate, DateTime endDate, int clientID)
        {
            var assignment = Assignment.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && clientID == a.ClientID).ToList();
            var kpi = KPIs.GetAllKPIs().Where(k => {
                foreach (AssignmentVM assign in assignment)
                {
                    if (assign.AssignmentID == k.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return GetEmployeeName(kpi).OrderBy(k => k.EmployeeName).ToList();
        }

        private List<KPIVM> GetEmployeeName(List<KPIVM> kpiList)
        {
            foreach (var kpi in kpiList)
            {
                kpi.EmployeeName = Employee.GetEmployeeByID(Assignment.GetAssignmentByID(kpi.AssignmentID).EmployeeID).EmployeeName;
            }
            return kpiList;
        }
    }
}
