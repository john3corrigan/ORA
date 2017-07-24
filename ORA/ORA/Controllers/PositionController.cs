using Lib.InterfacesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class PositionController : Controller
    {

        private IPositionLogic Positions;
        public PositionController(IPositionLogic pstns)
        {
            Positions = pstns;
        }

        public ActionResult ViewPosition(int AssignmentID)
        {
            return View(Positions.GetPositionByID(AssignmentID));
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult ViewAllPositions()
        {
            return View(Positions.GetAllPositions());
        }

        public JsonResult GetPositions()
        {
            var List = Positions.GetAllPositions();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}