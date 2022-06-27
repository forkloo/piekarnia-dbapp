using System;
using Piekarnia.Domain.DomainExceptions;
using Xunit;

namespace Piekarnia.Domain.Test
{
    public class ClientTest
    {
        public ClientTest(){

        }

        
        [Fact]
        public void CreateClient_Returns_throws_InvalidNameSurnameException()
        {
            Assert.Throws<InvalidNameSurnameException>(
                () => new Domain.Client("Name2", "Surname9", "Mail", "City"));
        }

        [Fact]
        public void CreateClient_Returns_Correct_Response(){
            var client = new Domain.Client("Name", "Surname", "Mail", "City");
            Assert.Equal("Name", client.ClientName);
            Assert.Equal("Surname", client.ClientSurname);
            Assert.Equal("Mail", client.ClientMail);
            Assert.Equal("City", client.ClientCity);
        }
    }
}