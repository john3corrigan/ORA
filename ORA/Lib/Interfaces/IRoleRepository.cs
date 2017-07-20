using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IRoleRepository {
        List<RoleVM> GetAllRoles();
        RoleVM GetRoleByID(int id);
        void AddRole(RoleVM role);
        void UpdateRole(RoleVM role);
        void DeleteRole(RoleVM role);
    }
}
