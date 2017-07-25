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
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectVM>().ReverseMap();
            });
        }

        public List<ProjectVM> GetAllProjects() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<ProjectVM>>(DbSet.Include("KPI"));
        }

        public ProjectVM GetProjectByID(int id) {
            var mapper = config.CreateMapper();
            return GetAllProjects().Where(p => p.ProjectID == id).FirstOrDefault();
        }

        public void AddProject(ProjectVM project) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Project>(project));
            Save();
        }

        public void UpdateProject(ProjectVM project) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Project>(project));
            Save();
        }

        public void DeleteProject(ProjectVM project) {
            Delete(project.ProjectID);
            Save();
        }
    }
}
