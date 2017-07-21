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

        public ProjectLogic(IProjectRepository prjct)
        {
            Projects = prjct;
        }

        public void AddProject(ProjectVM newProject)
        {
            Projects.AddProject(newProject);
        }

        public ProjectVM GetProjectByID(int projectID)
        {
            return Projects.GetProjectByID(projectID);
        }

        public List<ProjectVM> GetAllProjects()
        {
            return Projects.GetAllProjects();
        }

        public void UpdateProject(ProjectVM updatedProject)
        {
            Projects.UpdateProject(updatedProject);
        }

        public void DeleteProject(int projectID)
        {
            Projects.DeleteProject(Projects.GetProjectByID(projectID));
        }
    }
}
