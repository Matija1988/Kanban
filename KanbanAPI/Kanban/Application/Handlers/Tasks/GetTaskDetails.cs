
using Domain.GeneralErrors;

namespace Application.Handlers.Tasks;

public sealed record GetTaskDetailsQuery(Guid Id) : IRequest<Result<TodoResponse>>;

public sealed class GetTaskDetails(IApplicationDbContext context) : IRequestHandler<GetTaskDetailsQuery, Result<TodoResponse>>
{
    public async Task<Result<TodoResponse>> Handle(GetTaskDetailsQuery request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks
            .AsNoTracking()
            .AsSplitQuery()
            .Include(t => t.Comments)
            .Include(t => t.UserToDos)
            .ThenInclude(utd => utd.User)
              .Select(x => new TodoResponse
              {
                  Id = x.Id,
                  DateCreated = x.DateCreated,
                  CreatedBy = x.CreatedBy ?? "",
                  DateModified = x.DateModified,
                  ModifiedBy = x.ModifiedBy,
                  Title = x.Title,
                  Description = x.Description,
                  DateEnd = x.DateEnd,
                  DateStart = x.DateStart,
                  Status = x.Status.ToString(),
                  Priority = x.Priority.ToString(),
                  RowVersion = x.RowVersion.ToString(),

                  Comments = x.Comments.Select(c => new CommentResponse(
                      c.Id,
                      c.DateCreated,
                      c.CreatedBy ?? "",
                      c.Tekst
                  )).ToList(),

                  Users = x.UserToDos.Select(ut => new UserResponse(
                      ut.User.Id,
                      ut.User.Username,
                      ut.User.Email,
                      ut.User.Role.Name
                  )).ToList()
              })
            .FirstOrDefaultAsync(t => t.Id == request.Id);

        if(request == null)
        {
            return Result.Failure<TodoResponse>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.Id));
        }

        return Result.Success(task);
    }
}
