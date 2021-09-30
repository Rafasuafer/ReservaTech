using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class CreateUserDto
    {
	    public string Email { get; set; }
	    public string Password { get; set; }
    }
}
