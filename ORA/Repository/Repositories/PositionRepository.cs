using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;

namespace Repository.Repositories {
    public class PositionRepository : BaseRespository<Position, PositionVM>, IPositionRepository {
        public PositionRepository() : base() { }

        public List<PositionVM> GetAllPositions() {
            //TODO add includes
            return Mapper.Map<List<PositionVM>>(dbset.Include("Metadata").Include("Assignment"));
        }

        public PositionVM GetPositionByID(int id) {
            var position = GetAllPositions().Where(p => p.PositionID == id).FirstOrDefault();
            return Mapper.Map<PositionVM>(position);
        }
    }
}
