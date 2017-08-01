using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;
using Repository.Context;

namespace Repository.Repositories {
    public class PositionRepository : BaseRespository<Position>, IPositionRepository {
        public PositionRepository() : base(new RepositoryContext("ora")) {
        }

        public List<PositionVM> GetAllPositions() {
            return Mapper.Map<List<PositionVM>>(DbSet.Include("Assignment").ToList());
        }

        public PositionVM GetPositionByID(int id) {
            var position = GetAllPositions().Where(p => p.PositionID == id).FirstOrDefault();
            return Mapper.Map<PositionVM>(position);
        }

        public void AddPosition(PositionVM position) {
            Add(Mapper.Map<Position>(position));
            Save();
        }

        public void UpdatePosition(PositionVM position) {
            Update(Mapper.Map<Position>(position));
            Save();
        }

        public void DeletePosition(int id) {
            Delete(id);
            Save();
        }
    }
}
