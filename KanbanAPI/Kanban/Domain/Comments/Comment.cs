using Domain.ToDos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Comments;

public class Comment : BaseEntity
{
    [StringLength(255), Required]
    public string Tekst { get; set; }

    public Guid ToDoId { get; set; }

    [ForeignKey(nameof(ToDoId))]
    public ToDo ToDo { get; set; }
}