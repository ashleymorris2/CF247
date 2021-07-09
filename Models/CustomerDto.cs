using System.ComponentModel.DataAnnotations;

namespace CF247TechTest.API.Models
{
    public class CustomerDto
    {
        [Required, MaxLength(35)] public string FirstName { get; set; }
        [Required, MaxLength(35)] public string Surname { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }

    public class CustomerDetailDto : CustomerDto
    {
        public int Id { get; set; }
    }
}