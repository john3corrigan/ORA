using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class ClientLogic
    {
        private IClientRepository Clients;

        public ClientLogic(IClientRepository client)
        {
            Clients = client;
        }

        public ClientVM GetClientByClientID(int ClientID)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientVM updatedClient)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int clientID)
        {
            throw new NotImplementedException();
        }

        public void AddClient(ClientVM client)
        {
            throw new NotImplementedException();
        }

        public List<ClientVM> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
