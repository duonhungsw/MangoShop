using System.ComponentModel.DataAnnotations;

namespace Common.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = new Guid();
}
