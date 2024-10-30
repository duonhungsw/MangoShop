using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mango.Service.AccountAPI.Models
{
    public class Role : BaseEntity
    {

        [Required]
        public string? RoleName { get; set; }
    }
}
