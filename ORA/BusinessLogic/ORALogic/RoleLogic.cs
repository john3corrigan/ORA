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
    public class RoleLogic : IRoleLogic
    {
        private IRoleRepository Roles;

        public RoleLogic(IRoleRepository rls)
        {
            Roles = rls;
        }

        public List<RoleVM> GetAllRoles()
        {
            return Roles.GetAllRoles();
        }

        public RoleVM GetRoleByID(int roleID)
        {
            return Roles.GetRoleByID(roleID);
        }

        public void AddRole(RoleVM newRole)
        {
            Roles.AddRole(newRole);
        }

        public void UpdateRole(RoleVM updatedRole)
        {
            Roles.UpdateRole(updatedRole);
        }

        public void DeleteRole(int roleID)
        {
            Roles.DeleteRole(roleID);
        }
    }
}
