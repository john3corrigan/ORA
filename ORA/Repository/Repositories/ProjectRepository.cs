using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;

namespace Repository.Repositories {
    public class ProjectRepository : BaseRespository<Project, ProjectVM>, IProjectRepository {
        public ProjectRepository() : base() { }

        public List<ProjectVM> GetAllProjects() {
            return Mapper.Map<List<ProjectVM>>(dbset.Include("Metadata").Include("KPI"));
        }

        public ProjectVM GetProjectByID(int id) {
            return GetAllProjects().Where(p => p.ProjectID == id).FirstOrDefault();
        }

        public void AddProject(ProjectVM project) {
            Add(Mapper.Map<Project>(project));
            Save();
        }

        public void UpdateProject(ProjectVM project) {
            Update(Mapper.Map<Project>(project));
            Save();
        }

        public void DeleteProject(ProjectVM project) {
            Delete(project.ProjectID);
            Save();
        }
    }
}
