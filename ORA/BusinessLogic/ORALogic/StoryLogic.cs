using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class StoryLogic : IStoryLogic
    {
        private IStoryRepository Stories;
        private IClientRepository Client;

        public StoryLogic(IStoryRepository stry, IClientRepository clnt)
        {
            Stories = stry;
            Client = clnt;
        }

        public StoryVM GetStoryByID(int storyID)
        {
            return Stories.GetStoryByID(storyID);
        }

        public void UpdateStory(StoryVM updatedStory)
        {
            Stories.UpdateStory(updatedStory);
        }

        public void DeleteStory(int storyID)
        {
            Stories.DeleteStory(storyID);
        }
        
        public void AddStory(StoryVM newStory)
        {
            Stories.AddStory(newStory);
        }

        public CreateStoryVM AddStory()
        {
            CreateStoryVM create = new CreateStoryVM() {
                ClientList = Client.GetAllClients()
            };
            return create;
        }

        public List<StoryVM> GetAllStories()
        {
            List<StoryVM> StoryList = Stories.GetAllStories();
            foreach (StoryVM story in StoryList)
            {
                story.Client = Client.GetClientByID(story.ClientID);
            }
            return StoryList;
        }
    }
}
