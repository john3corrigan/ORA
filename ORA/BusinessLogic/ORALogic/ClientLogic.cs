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
    public class ClientLogic : IClientLogic
    {
        private IClientRepository Clients;

        public ClientLogic(IClientRepository clnt)
        {
            Clients = clnt;
        }

        public ClientVM GetClientByID(int ClientID)
        {
            return Clients.GetClientByID(ClientID);
        }

        public void UpdateClient(ClientVM updatedClient)
        {
            Clients.UpdateClient(updatedClient);
        }

        public void RemoveClient(int clientID)
        {
            Clients.RemoveClient(clientID);
        }

        public void AddClient(ClientVM client)
        {
            Clients.AddClient(client);
        }

        public List<ClientVM> GetAllClients()
        {
            return Clients.GetAllClients();
        }
    }
}
