using Lib.Attributes;
using Lib.InterfacesLogic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    [Authorize]
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

        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult ViewAllPositions()
        {
            return View(Positions.GetAllPositions());
        }
    }
}