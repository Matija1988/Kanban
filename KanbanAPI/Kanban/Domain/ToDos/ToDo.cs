using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Comments;
using Domain.N2NEntities;
using Common;

namespace Domain.ToDos;

[Table("Tasks")]
public class ToDo : BaseEntity
{
    [StringLength(200), Required]
    public string Title { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(30), Required]
    public string DateStart { get; set; }
    [StringLength(30), Required]
    public string DateEnd { get; set; }
    public bool isInProgress { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public Priority Priority { get; set; } = Priority.MED;

    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    public ICollection<UserToDo>? UserToDos { get; set; } = new List<UserToDo>();

}
