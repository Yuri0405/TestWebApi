using System.IO;
using System.Threading.Tasks;
using TestWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;

namespace TestWebApi.Services
{
    public class JsonClientFileProcessor
    {
        private readonly string _path;

        public JsonClientFileProcessor(IConfiguration configuration)
        {
            _path = configuration.GetSection("ClientDataFolder").Value;
        }
        public async Task<List<Client>> GetClients(string phoneNumber)
        {
            List<Client> clients = new List<Client>();
            
            using(FileStream fs = new FileStream(_path,FileMode.OpenOrCreate))
            {

                clients = await JsonSerializer.DeserializeAsync<List<Client>>(fs);

            }

            return clients.Where(c => c.PhoneNumber == phoneNumber).ToList();
        }

        public async void RecordClient(Client client)
        {
            List<Client> clients = new List<Client>();

            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {

                clients = await JsonSerializer.DeserializeAsync<List<Client>>(fs);

            }

            using (FileStream fs = new FileStream(_path, FileMode.Create))
            {
                clients.Add(client);
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync(fs, clients,options);
            }
        }
    }
}
