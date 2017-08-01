using Lib.Attributes;
using Lib.InterfacesLogic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
        
        public ActionResult ViewAllPositions()
        {
            return View(Positions.GetAllPositions());
        }
    }
}