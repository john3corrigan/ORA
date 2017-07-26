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

namespace Repository.Repositories{
    public class StoryRepository : BaseRespository<Story>, IStoryRepository {
        public StoryRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Story, StoryVM>().ReverseMap();
                cfg.CreateMap<KPI, KPIVM>().ReverseMap();
            });
        }

        public List<StoryVM> GetAllStories() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<StoryVM>>(DbSet.Include("KPI"));
        }

        public StoryVM GetStoryByID(int id) {
            var mapper = config.CreateMapper();
            var story = GetAllStories().Where(s => s.StoryID == id).FirstOrDefault();
            return mapper.Map<StoryVM>(story);
        }

        public void AddStory(StoryVM story) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Story>(story));
            Save();
        }

        public void UpdateStory(StoryVM story) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Story>(story));
            Save();
        }

        public void DeleteStory(int id) {
            Delete(id);
            Save();
        }
    }
}
