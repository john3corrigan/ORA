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
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Position, PositionVM>().ReverseMap();
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
            });
        }

        public List<PositionVM> GetAllPositions() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<PositionVM>>(DbSet.Include("Assignment"));
        }

        public PositionVM GetPositionByID(int id) {
            var mapper = config.CreateMapper();
            var position = GetAllPositions().Where(p => p.PositionID == id).FirstOrDefault();
            return mapper.Map<PositionVM>(position);
        }

        public void AddPosition(PositionVM position) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Position>(position));
            Save();
        }

        public void UpdatePosition(PositionVM position) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Position>(position));
            Save();
        }

        public void DeletePosition(int id) {
            Delete(id);
            Save();
        }
    }
}
