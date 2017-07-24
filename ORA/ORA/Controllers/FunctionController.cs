using Lib.InterfacesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class FunctionController : Controller
    {

        private IAssessmentLogic Assessments;
        private IAssignmentLogic Assignments;
        private IClientLogic Clients;
        private IEmployeeLogic Employees;
        private IKPILogic KPIs;
        private IPositionLogic Positions;
        private IProjectLogic Projects;
        private IRoleLogic Roles;
        private ISprintLogic Sprints;
        private IStoryLogic Stories;
        private ITeamLogic Teams;
        public FunctionController(IAssessmentLogic assess, IAssignmentLogic assign, IClientLogic clnts, IEmployeeLogic emplys, IKPILogic kpi, IPositionLogic pstns, IProjectLogic prjct, IRoleLogic rls, ISprintLogic sprnt, IStoryLogic stry, ITeamLogic tms)
        {
            Assessments = assess;
            Assignments = assign;
            Clients = clnts;
            Employees = emplys;
            KPIs = kpi;
            Positions = pstns;
            Projects = prjct;
            Roles = rls;
            Sprints = sprnt;
            Stories = stry;
            Teams = tms;
        }

        public JsonResult GetAssessments()
        {
            var List = Assessments.GetAllAssessments();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAssignments()
        {
            var List = Assignments.GetAllAssignments();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClients()
        {
            var List = Clients.GetAllClients();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployees()
        {
            var List = Employees.GetAllEmployees();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetKPIs()
        {
            var List = KPIs.GetAllKPIs();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPositions()
        {
            var List = Positions.GetAllPositions();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var List = Projects.GetAllProjects();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRoles()
        {
            var List = Roles.GetAllRoles();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSprints()
        {
            var List = Sprints.GetAllSprints();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStories()
        {
            var List = Stories.GetAllStories();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeams()
        {
            var List = Teams.GetAllTeams();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}