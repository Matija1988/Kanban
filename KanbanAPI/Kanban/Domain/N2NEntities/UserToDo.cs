using Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.ToDos;

namespace Domain.N2NEntities;

public class UserToDo
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [Required]
    public Guid ToDoId { get; set; }

    [ForeignKey("ToDoId")]
    public ToDo ToDo { get; set; }

    [StringLength(30), Required]
    public string AssignedDate { get; set; }

    [StringLength(30)]
    public string? RemovedDate { get; set; }
}