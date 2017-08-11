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
        private IEmployeeRepository Employees;

        public ClientLogic(IClientRepository clnt, IEmployeeRepository emply)
        {
            Clients = clnt;
            Employees = emply;
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

        public List<ClientVM> GetClientsManager(int empID)
        {
            var assignments = Employees.GetEmployeeByID(empID).Assignment.Where(a => a.RoleID > 7).ToList();
            return Clients.GetAllClients().Where(c => {
                foreach(var assign in assignments)
                {
                    if (assign.ClientID == c.ClientID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
        }
    }
}
