using System;
using System.Threading.Tasks;
using Piekarnia.Common.Enums;
using Piekarnia.Domain.DomainExceptions;
using Piekarnia.IData.Client;
using Piekarnia.IServices.Requests;
using Piekarnia.IServices.Client;
using Piekarnia.Services.Client;
using Moq;
using Xunit;

namespace Piekarnia.Services.Test
{
    public class ClientServiceTest
    {
        private readonly IClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepositoryMock;

        public ClientServiceTest(){
            _clientRepositoryMock = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepositoryMock.Object);
        }

        [Fact]
        public void CreateClient_Returns_throws_InvalidNameSurnameException()
        {
            var client = new CreateClient
            {
                ClientName = "Name2",
                ClientSurname = "Surname44",
                ClientMail = "Mail",
                ClientCity = "City"
            };
            Assert.ThrowsAsync<InvalidNameSurnameException>(() => _clientService.CreateClient(client));
        }

        [Fact]
        public async Task CreateClient_Returns_Correct_Response(){
            var client = new CreateClient
            {
                ClientName = "Name",
                ClientSurname = "Surname",
                ClientMail = "Mail",
                ClientCity = "City"
            };

            int expectedResult = 0;
            _clientRepositoryMock.Setup(x => x.AddClient(
                new Domain.Client(client.ClientName, client.ClientSurname, client.ClientMail, client.ClientCity)
                )).Returns(Task.FromResult(expectedResult));

            var result = await _clientService.CreateClient(client);
            Assert.IsType<Domain.Client>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.ClientId);
        }
    }
}