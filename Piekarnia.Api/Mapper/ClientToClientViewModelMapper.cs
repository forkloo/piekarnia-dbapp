using Piekarnia.Api.ViewModels;

namespace Piekarnia.Api.Mapper
{
    public class ClientToClientViewModelMapper
    {
        public static ClientViewModel ClientToClientViewModel(Domain.Client _client){
            var clientViewModel = new ClientViewModel
            {
                ClientId = _client.ClientId,
                ClientName = _client.ClientName,
                ClientSurname = _client.ClientSurname,
                ClientCity = _client.ClientCity,
                ClientMail = _client.ClientMail
            };
            return clientViewModel;
        }
    }
}
