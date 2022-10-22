using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestWebApi.Models
{
    public class Client
    {
        [JsonPropertyName("firstname")]
        public string? FirstName { get; set; }
        
        [JsonPropertyName("lastname")]
        public string? LastName { get; set; }
        
        [JsonPropertyName("middlename")]
        public string? MiddleName { get; set; }
        
        [JsonPropertyName("phone")]
        public string? PhoneNumber { get; set; }
        
        [JsonPropertyName("addressCity")]
        public string? AddressCity { get; set; }
        
        [JsonPropertyName("street")]
        public string? Street { get; set; }
        
        [JsonPropertyName("apartment")]
        public string? Apartment { get; set; }
        
        [JsonPropertyName("house")]
        public string? House { get; set; }

        public override string ToString()
        {
            return $"Прізвище:{LastName}\nІм’я:{FirstName}\nПо батькові:{MiddleName}\nТелефон:{PhoneNumber}\nМісто:{AddressCity}\nВулиця:{Street}\nКвартира:{Apartment}\nБудинок:{House}";
        }
    }
}
