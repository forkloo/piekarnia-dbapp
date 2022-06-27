using System.Threading.Tasks;
using Piekarnia.IData.Client;
using Piekarnia.IServices.Requests;
using Piekarnia.IServices.Client;

namespace Piekarnia.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        
        public ClientService(IClientRepository clientRepository){
            _clientRepository = clientRepository;
        }

        public Task<Domain.Client> GetClientByClientId(int clientId){
            return _clientRepository.GetClient(clientId);
        }

        public Task<Domain.Client> GetClientByClientSurname(string clientSurname){
            return _clientRepository.GetClient(clientSurname);
        }
        
        public async Task<Domain.Client> CreateClient(CreateClient createClient)
        {
            var client = new Domain.Client(createClient.ClientName, createClient.ClientSurname, createClient.ClientMail, createClient.ClientCity);
            client.ClientId = await _clientRepository.AddClient(client);
            return client;
        }

        public async Task EditClient(EditClient createClient, int clientId){
            var client = await _clientRepository.GetClient(clientId);
            client.EditClient(createClient.ClientName, createClient.ClientSurname, createClient.ClientMail, createClient.ClientCity);
            await _clientRepository.EditClient(client);
        }

        public async Task DeleteClient(int clientId)
        {
            await _clientRepository.DeleteClient(clientId);
        }
    }
}
