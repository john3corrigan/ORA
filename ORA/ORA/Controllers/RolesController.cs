using Lib.Attributes;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Web.Mvc;

namespace ORA.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private IRoleLogic Roles;

        public RolesController(IRoleLogic rls)
        {
            Roles = rls;
        }

        // GET: Role
        public ActionResult Index()
        {
            return View(Roles.GetAllRoles());
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult AddRole(RoleVM Role)
        {
            Roles.AddRole(Role);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult UpdateRole(int RoleID)
        {
            return View(Roles.GetRoleByID(RoleID));
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleVM updatedRole)
        {
            Roles.UpdateRole(updatedRole);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult ViewRole(int AssignmentID)
        {
            return View(Roles.GetRoleByID(AssignmentID));
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult DeleteRole(int RoleID)
        {
            Roles.DeleteRole(RoleID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}