using System.Threading.Tasks;
using Piekarnia.IData.Client;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Piekarnia.Data.Sql.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly PiekarniaDbContext _context;

        public ClientRepository(PiekarniaDbContext context){
            _context = context;
        }

        public async Task<int> AddClient(Domain.Client client){
            var clientDAO = new DAO.Client
            {
                ClientMail = client.ClientMail,
                ClientName = client.ClientName,
                ClientSurname = client.ClientSurname,
                ClientCity = client.ClientCity,
                ClientStreet = client.ClientStreet,
                ClientBuildingNumber = client.ClientBuildingNumber,
                ClientPhone = client.ClientPhone
            };
            await _context.AddAsync(clientDAO);
            await _context.SaveChangesAsync();
            return clientDAO.ClientId;
        }
        public async Task<Domain.Client> GetClient(int clientId){
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);
            return new Domain.Client(
                client.ClientId,
                client.ClientMail,
                client.ClientName,
                client.ClientSurname,
                client.ClientCity,
                client.ClientStreet,
                client.ClientPhone,
                client.ClientBuildingNumber
            );
        }
        public async Task<Domain.Client> GetClient(string clientSurname){
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientSurname == clientSurname);
            return new Domain.Client(
                client.ClientId,
                client.ClientMail,
                client.ClientName,
                client.ClientSurname,
                client.ClientCity,
                client.ClientStreet,
                client.ClientPhone,
                client.ClientBuildingNumber
            );
        }
        public async Task EditClient(Domain.Client client){
            var editClient = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
            editClient.ClientName = client.ClientName;
            editClient.ClientSurname = client.ClientSurname;
            editClient.ClientMail = client.ClientMail;
            editClient.ClientCity = client.ClientCity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(int clientId)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);
            if(client == null){
                throw new Exception("Client not found");
            }
            IQueryable<DAO.Order> clientOrderIds = _context.Order.Where(x => x.ClientId == clientId);

            _context.Order.RemoveRange(clientOrderIds);
            foreach(var order in await clientOrderIds.ToListAsync()){
                int orderId = order.OrderId;
                _context.SellerOrder.RemoveRange(_context.SellerOrder.Where(x => x.OrderId == orderId));
                _context.ProductOrder.RemoveRange(_context.ProductOrder.Where(x => x.OrderId == orderId));
            }
            

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
