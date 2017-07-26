using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using Repository.Context;

namespace Repository.Repositories {
    public class KPIRepository : BaseRespository<KPI>, IKPIRepository {
        public KPIRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<KPI, KPIVM>().ReverseMap();
                cfg.CreateMap<CreateKPIVM, KPI>();
            });
        }

        public List<KPIVM> GetAllKPIs() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<KPIVM>>(GetAll());
        }

        public KPIVM GetKPIByID(int id) {
            var mapper = config.CreateMapper();
            var kpi = GetAllKPIs().Where(k => k.KPIID == id).FirstOrDefault();
            return mapper.Map<KPIVM>(kpi);
        }

        public void AddKPI(CreateKPIVM kpi) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<KPI>(kpi));
            Save();
        }

        public void UpdateKPI(KPIVM kpi) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<KPI>(kpi));
            Save();
        }

        public void DeleteKPI(int id) {
            Delete(id);
            Save();
        }
    }
}
