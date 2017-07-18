using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories {
    public class PositionRepository : BaseRespository<Position, PositionVM> {
        public PositionRepository() : base() { }

        public List<PositionVM> GetAllPositions() {
            //TODO add includes
            return Mapper.Map<List<PositionVM>>(GetAll());
        }

        public PositionVM GetPositionByID(int id) {
            return Mapper.Map<PositionVM>(GetByID(id));
        }
    }
}
