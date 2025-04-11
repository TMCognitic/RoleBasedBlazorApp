using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Api.Models.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Passwd { get; set; }
    }
}
