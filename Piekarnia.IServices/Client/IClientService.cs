using System.Threading.Tasks;
using Piekarnia.IServices.Requests;

namespace Piekarnia.IServices.Client
{
    public interface IClientService
    {
        Task<Domain.Client> GetClientByClientId(int clientId);
        Task<Domain.Client> GetClientByClientSurname(string clientSurname);
        Task<Domain.Client> CreateClient(CreateClient createClient);

        Task EditClient(EditClient createUser, int clientId);

        Task DeleteClient(int clientId);
    }
}