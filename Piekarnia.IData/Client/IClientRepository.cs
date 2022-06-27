using System.Threading.Tasks;

namespace Piekarnia.IData.Client
{
    public interface IClientRepository
    {
        Task<int> AddClient(Domain.Client client);
        Task<Domain.Client> GetClient(int clientId);
        Task<Domain.Client> GetClient(string clientSurname);
        Task EditClient(Domain.Client client);
        Task DeleteClient(int clientId);
    }
}