using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class PositionLogic
    {
        private IPositionRepository Positions;

        public PositionLogic(IPositionRepository pstn)
        {
            Positions = pstn;
        }
        public PositionVM GetPositionByID(int KPIID)
        {
            throw new NotImplementedException();
        }

        public List<PositionVM> GetAllPositions()
        {
            throw new NotImplementedException();
        }
    }
}
