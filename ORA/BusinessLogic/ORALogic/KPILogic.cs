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
    }
}
