using System;
using System.Threading.Tasks;
using Piekarnia.Api.BindingModels;
using Piekarnia.Api.Validation;
using Piekarnia.Api.ViewModels;
using Piekarnia.Api.Mapper;
using Piekarnia.Data.Sql;
using Piekarnia.Data.Sql.DAO;
using Piekarnia.IServices.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Piekarnia.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client")]
    public class ClientController: Controller
    {
        private readonly PiekarniaDbContext _context;
        private readonly IClientService _clientService;
        public ClientController(PiekarniaDbContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }


        [HttpGet("{clientId:min(1)}", Name ="GetClientById")]
        public async Task<IActionResult> GetClientById(int clientId){
            var client = await _clientService.GetClientByClientId(clientId);
            if(client != null){
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }
            return NotFound();
        }
        [HttpGet("client/{clientSurname}", Name="GetClientByClientSurname")]
        public async Task<IActionResult> GetClientByClientSurname(string clientSurname){
            var client = await _clientService.GetClientByClientSurname(clientSurname);
            if(client != null){
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }
            return NotFound();
        }

        [HttpDelete("delete/{clientId:min(1)}", Name = "DeleteClientById")]
        public async Task<IActionResult> DeleteClientById(int clientId)
        {
            await _clientService.DeleteClient(clientId);
            return NoContent();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateClient createClient){
            var client = await _clientService.CreateClient(createClient);
            return Created(client.ClientId.ToString(), ClientToClientViewModelMapper.ClientToClientViewModel(client));
        }
        [ValidateModel]
        [HttpPatch("edit/{clientId:min(1)}", Name = "EditClient")]
        public async Task<IActionResult> EditClient([FromBody] IServices.Requests.EditClient editClient, int clientId){
            await _clientService.EditClient(editClient, clientId);
            return NoContent();
        }
    }
}
