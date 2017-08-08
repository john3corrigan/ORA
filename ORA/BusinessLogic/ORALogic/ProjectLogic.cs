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
    public class ProjectLogic : IProjectLogic
    {
        private IProjectRepository Projects;
        private IClientRepository Clients;

        public ProjectLogic(IProjectRepository prjct,
            IClientRepository clnts)
        {
            Projects = prjct;
            Clients = clnts;
        }

        public CreateProjectVM AddProject()
        {
            CreateProjectVM create = new CreateProjectVM()
            {
                ClientList = Clients.GetAllClients()
            };
            return create;
        }

        public void AddProject(CreateProjectVM newProject)
        {
            //newProject.ClientID = newProject.Client.ClientID; //NullError: Object reference not set to an instance of an object
            newProject.Client = Clients.GetClientByID(newProject.ClientID);
            Projects.AddProject(newProject);
        }

        public ProjectVM GetProjectByID(int projectID)
        {
            return Projects.GetProjectByID(projectID);
        }

        public List<ProjectVM> GetProjectByClientID(int ClientID)
        {
            return Projects.GetAllProjects().Where(p => p.ClientID == ClientID).ToList();
        }

        public List<ProjectVM> GetAllProjects()
        {
            List<ProjectVM> ProjectList = Projects.GetAllProjects();
            foreach (ProjectVM project in ProjectList)
            {
                project.Client = Clients.GetClientByID(project.ClientID);
            }
            return ProjectList;
        }

        public void UpdateProject(ProjectVM updatedProject)
        {
            Projects.UpdateProject(updatedProject);
        }

        public void DeleteProject(int projectID)
        {
            Projects.DeleteProject(projectID);
        }
    }
}
