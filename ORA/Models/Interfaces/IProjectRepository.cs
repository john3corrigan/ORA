using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IProjectRepository {
        List<ProjectVM> GetAllProjects();
        ProjectVM GetProjectByID(int id);
        void AddProject(ProjectVM project);
        void UpdateProject(ProjectVM project);
        void DeleteProject(ProjectVM project);
    }
}
