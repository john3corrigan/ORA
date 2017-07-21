using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IStoryRepository {
        List<StoryVM> GetAllStories();
        StoryVM GetStoryByID(int id);
        void AddStory(StoryVM story);
        void UpdateStory(StoryVM story);
        void DeleteStory(StoryVM story);
    }
}
