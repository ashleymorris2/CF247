using System.ComponentModel.DataAnnotations;

namespace CF247TechTest.API.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(35)] public string FirstName { get; set; }
        [Required, MaxLength(35)] public string Surname { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}