using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using Repository.Context;

namespace Repository.Repositories {
    public class ProjectRepository : BaseRespository<Project>, IProjectRepository {
        public ProjectRepository() : base(new RepositoryContext("ora")) {
        }

        public List<ProjectVM> GetAllProjects() {
            return Mapper.Map<List<ProjectVM>>(DbSet.Include("KPI").ToList());
        }

        public ProjectVM GetProjectByID(int id) {
            return GetAllProjects().Where(p => p.ProjectID == id).FirstOrDefault();
        }

        public void AddProject(CreateProjectVM project) {
            Add(Mapper.Map<Project>(project));
            Save();
        }

        public void UpdateProject(ProjectVM project) {
            Update(Mapper.Map<Project>(project));
            Save();
        }

        public void DeleteProject(int id) {
            Delete(id);
            Save();
        }
    }
}
