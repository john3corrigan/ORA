using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories{
    public class StoryRepository : BaseRespository<Story, StoryVM> {
        public StoryRepository() : base() { }

        public List<StoryVM> GetAllStories() {
            return Mapper.Map<List<StoryVM>>(dbset.Include("Metadata").Include("KPI"));
        }

        public StoryVM GetStoryByID(int id) {
            var story = GetAllStories().Where(s => s.StoryID == id).FirstOrDefault();
            return Mapper.Map<StoryVM>(story);
        }

        public void AddStory(StoryVM story) {
            Add(Mapper.Map<Story>(story));
            Save();
        }

        public void UpdateStory(StoryVM story) {
            Update(Mapper.Map<Story>(story));
            Save();
        }

        public void DeleteStory(StoryVM story) {
            Delete(story.StoryID);
            Save();
        }
    }
}
