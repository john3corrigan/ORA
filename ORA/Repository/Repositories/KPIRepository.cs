﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;

namespace Repository.Repositories {
    public class KPIRepository : BaseRespository<KPI, KPIVM> {
        public KPIRepository() : base() { }

        public List<KPIVM> GetAllKPIs() {
            return Mapper.Map<List<KPIVM>>(GetAll());
        }

        public KPIVM GetKPIByID(int id) {
            var kpi = GetAllKPIs().Where(k => k.KPIID == id).FirstOrDefault();
            return Mapper.Map<KPIVM>(kpi);
        }

        public void AddKPI(KPIVM kpi) {
            Add(Mapper.Map<KPI>(kpi));
            Save();
        }

        public void UpdateKPI(KPIVM kpi) {
            Update(Mapper.Map<KPI>(kpi));
            Save();
        }
    }
}
