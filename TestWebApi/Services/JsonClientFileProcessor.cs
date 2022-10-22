using System.IO;
using System.Threading.Tasks;
using TestWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;


namespace TestWebApi.Services
{
    public class JsonClientFileProcessor
    {
        public async Task<List<Client>> GetClients(string phoneNumber)
        {
            List<Client> clients = new List<Client>();
            
            using(FileStream fs = new FileStream("D:/Some projects/TestWebApi/TestWebApi/ClientsDataFiles/Clients.json",FileMode.Open))
            {

                clients = await JsonSerializer.DeserializeAsync<List<Client>>(fs);

            }

            return clients.Where(c => c.PhoneNumber == phoneNumber).ToList();
        }

        public async void RecordClient(Client client)
        {
            List<Client> clients = new List<Client>();

            using (FileStream fs = new FileStream("D:/Some projects/TestWebApi/TestWebApi/ClientsDataFiles/Clients.json", FileMode.Open))
            {

                clients = await JsonSerializer.DeserializeAsync<List<Client>>(fs);

            }

            using (FileStream fs = new FileStream("D:/Some projects/TestWebApi/TestWebApi/ClientsDataFiles/Clients.json", FileMode.Create))
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
