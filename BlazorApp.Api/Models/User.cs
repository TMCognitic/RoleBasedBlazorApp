using System.Text.Json.Serialization;

namespace BlazorApp.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        
        [JsonIgnore]
        public string? Passwd { get; set; }
        public required string Role { get; set; }
    }
}
