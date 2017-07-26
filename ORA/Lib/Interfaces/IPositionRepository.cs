using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IPositionRepository {
        List<PositionVM> GetAllPositions();
        PositionVM GetPositionByID(int id);
        void AddPosition(PositionVM position);
        void UpdatePosition(PositionVM position);
        void DeletePosition(int id);
    }
}
