using Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Service.AccountAPI.Models;

public class User : BaseEntity
{

    [Required]
    [MinLength(2, ErrorMessage = "First name must have ablest 2 character")]

    public string FirstName { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Last name must have ablest 2 character")]

    public string LastName { get; set; }
    [MinLength(8, ErrorMessage = "User name must have ablest 8 character")]

    public string UserName { get; set; }
    [MinLength(8, ErrorMessage = "Phone number must have ablest 8 character")]

    public string PhoneNumber { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password must have ablest 8 character")]
    public string Password { get; set; }
    public string? PictureUrl { get; set; }
    public bool IsDeleted { get; set; } = false;
    [Required]
    public Guid RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
}
