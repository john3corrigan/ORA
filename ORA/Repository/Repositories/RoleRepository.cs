using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;
using Repository.Context;

namespace Repository.Repositories {
    public class RoleRepository : BaseRespository<Role>, IRoleRepository {
        private MapperConfiguration config;
        public RoleRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Role, RoleVM>();
                cfg.CreateMap<RoleVM, Role>();
            });
        }

        public List<RoleVM> GetAllRoles() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<RoleVM>>(DbSet.Include("Metadata").Include("Assignment"));
        }

        public RoleVM GetRoleByID(int id) {
            var role = GetAllRoles().Where(r => r.RoleID == id).FirstOrDefault();
            var mapper = config.CreateMapper();
            return mapper.Map<RoleVM>(role);
        }

        public void AddRole(RoleVM role) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Role>(role));
            Save();
        }

        public void UpdateRole(RoleVM role) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Role>(role));
            Save();
        }

        public void DeleteRole(RoleVM role) {
            Delete(role.RoleID);
            Save();
        }
    }
}
