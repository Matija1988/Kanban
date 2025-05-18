using Domain.Comments;
using Domain.N2NEntities;
using Domain.Roles;
using Domain.ToDos;
using Domain.Users;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<ToDo> Tasks { get; set; }
    DbSet<Comment> Comments { get; set; }

    DbSet<UserToDo> UserToDos { get; set; }
    DbSet<Role> Roles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
