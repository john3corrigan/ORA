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
    public class PositionLogic : IPositionLogic
    {
        private IPositionRepository Positions;

        public PositionLogic(IPositionRepository pstn)
        {
            Positions = pstn;
        }
        public PositionVM GetPositionByID(int positionID)
        {
            return Positions.GetPositionByID(positionID);
        }

        public List<PositionVM> GetAllPositions()
        {
            return Positions.GetAllPositions();
        }
    }
}
