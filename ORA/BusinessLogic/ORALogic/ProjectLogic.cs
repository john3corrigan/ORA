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
    public class ProjectLogic
    {
        private IProjectRepository Projects;

        public ProjectLogic(IProjectRepository prjct)
        {
            Projects = prjct;
        }

        public void CreateProject(ProjectVM project)
        {
            throw new NotImplementedException();
        }

        public ProjectVM GetProjectByProjectID(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<ProjectVM> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(ProjectVM updatedProject)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int projectID)
        {
            throw new NotImplementedException();
        }
    }
}
