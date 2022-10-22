using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly JsonClientFileProcessor _processor;

        public ClientsController(JsonClientFileProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<ActionResult> GetClients(string phonenumber)
        {
            List<Client> client = await _processor.GetClients(phonenumber);
            string response = null;
            foreach(Client clientItem in client)
            {
                response += clientItem.ToString() + " \n\n";
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult PostClient(Client client)
        {
            _processor.RecordClient(client);
            return Ok("Client Recorded");
        }
        
    }
}
