using Lib.InterfacesLogic;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class RolesController : Controller
    {
        private IRoleLogic Roles;

        public RolesController(IRoleLogic clnts)
        {
            Roles = clnts;
        }

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(RoleVM Role)
        {
            Roles.AddRole(Role);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateRole(int RoleID)
        {
            return View(Roles.GetRoleByID(RoleID));
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleVM updatedRole)
        {
            Roles.UpdateRole(updatedRole);
            return View("");
        }

        public ActionResult ViewRole(int AssignmentID)
        {
            return View(Roles.GetRoleByID(AssignmentID));
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult ViewAllRoles()
        {
            return View(Roles.GetAllRoles());
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteRole(int RoleID)
        {
            Roles.DeleteRole(RoleID);
            return View("");
        }
        public JsonResult GetRoles()
        {
            var List = Roles.GetAllRoles();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}