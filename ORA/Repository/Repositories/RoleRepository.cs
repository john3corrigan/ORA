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
        public RoleRepository() : base(new RepositoryContext("ora")) {
        }

        public List<RoleVM> GetAllRoles() {
            return Mapper.Map<List<RoleVM>>(DbSet.Include("Assignment").ToList());
        }

        public RoleVM GetRoleByID(int id) {
            var role = GetAllRoles().Where(r => r.RoleID == id).FirstOrDefault();
            return Mapper.Map<RoleVM>(role);
        }

        public void AddRole(RoleVM role) {
            Add(Mapper.Map<Role>(role));
            Save();
        }

        public void UpdateRole(RoleVM role) {
            Update(Mapper.Map<Role>(role));
            Save();
        }

        public void DeleteRole(int id) {
            Delete(id);
            Save();
        }
    }
}
