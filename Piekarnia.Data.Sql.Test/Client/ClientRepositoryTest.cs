using System.Threading.Tasks;
using Piekarnia.Data.Sql.Client;
using Piekarnia.IData.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Piekarnia.Data.Sql.Test
{
    public class ClientRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private PiekarniaDbContext _context;
        private IClientRepository _clientRepository;

        public ClientRepositoryTest(){
            var optionsBuilder = new DbContextOptionsBuilder<PiekarniaDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=rootpass;port=3307;database=piekarnia_db;"
            );
            _context = new PiekarniaDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _clientRepository = new ClientRepository(_context);
        }
        
        [Fact]
        public async void AddClient_Returns_Correct_Response()
        {
            var client = new Domain.Client("Name", "Surname", "City", "Mail");
            var clientId = await _clientRepository.AddClient(client);
            var createdClient = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);
            _context.Client.Remove(createdClient);
            await _context.SaveChangesAsync();
        }
    }
}