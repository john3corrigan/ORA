using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories {
    public class RoleRepository : BaseRespository<Role, RoleVM>{
        public RoleRepository() : base() { }

        public List<RoleVM> GetAllRoles() {
            return Mapper.Map<List<RoleVM>>(dbset.Include("Metadata").Include("Assignment"));
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

        public void DeleteRole(RoleVM role) {
            Delete(role.RoleID);
            Save();
        }
    }
}
