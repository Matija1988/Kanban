using Domain.N2NEntities;
using Domain.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users;

[Table("Users")]
public class User : BaseEntity
{
    [StringLength(50)]
    public string Username { get; set; }

    [StringLength(255), Required]
    public string Password { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public Guid RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role Role { get; set; }

    public ICollection<UserToDo> UserToDos { get; set; } = new List<UserToDo>();
}
