using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IProjectLogic
    {
        List<ProjectVM> GetAllProjects();
        ProjectVM GetProjectByID(int projectID);
        void AddProject(ProjectVM project);
        void UpdateProject(ProjectVM updatedProject);
        void DeleteProject(int projectID);
    }
}
