using Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Roles;

[Table("Roles")]
public class Role
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(10), Required]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}