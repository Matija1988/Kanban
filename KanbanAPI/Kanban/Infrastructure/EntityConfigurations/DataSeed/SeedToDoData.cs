using Common;

namespace Infrastructure.EntityConfigurations.DataSeed;

public static class SeedToDoData
{
    public static void Seed(ApplicationDBContext context)
    {
        if (!context.Tasks.Any(t => t.CreatedBy == "seed"))
        {
            var now = DateTime.UtcNow;
            var startDate = DateOnly.FromDateTime(now);
            var endDate = now.AddMonths(1);

            context.Tasks.AddRange(
                new ToDo
                {
                    Id = Guid.Parse("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
                    DateCreated = now.ToString(),
                    DateModified = now.ToString(),
                    CreatedBy = "seed",
                    Title = "Increase power to the warp engine",
                    DateStart = startDate.ToString(),
                    DateEnd = endDate.ToString(),
                    Status = Status.IN_PROGRESS,
                    Priority = Priority.HIGH
                },
                new ToDo
                {
                    Id = Guid.Parse("47fb53da-e324-459e-9bb5-d2dccff741d7"),
                    DateCreated = now.ToString(),
                    DateModified = now.ToString(),
                    CreatedBy = "seed",
                    Title = "Task1",
                    DateStart = startDate.ToString(),
                    DateEnd = endDate.ToString(),
                    Status = Status.TO_DO,
                    Priority = Priority.MED
                },
                  new ToDo
                  {
                      Id = Guid.Parse("05fc5276-8a16-450d-ba3e-4760267ec381"),
                      DateCreated = DateTime.UtcNow.ToString(),
                      DateModified = DateTime.UtcNow.ToString(),
                      CreatedBy = "seed",
                      Title = "Task2",
                      DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                      DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                      Status = Status.TO_DO,
                      Priority = Priority.LOW
                  },
                    new ToDo
                    {
                        Id = Guid.Parse("de734256-7f1a-403d-a14c-6bd545426e08"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task3",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("ef66ce84-4ce5-468c-92da-4745160b4a8c"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task4",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("1be3e19f-13fe-4c3b-953e-eedbdee16134"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task5",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("0e70a5ca-5c3b-4ba4-a5c1-6a389a37f8df"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task6",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("09345fd8-9400-48c7-85e8-e2d5e082ac11"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task7",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       }
            // Add the rest...
            );

            context.SaveChangesAsync();
        }
    }
}
