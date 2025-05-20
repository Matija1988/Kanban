using Common;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.EntityConfigurations;

internal class ToDosConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(t => t.Comments)
             .WithOne(c => c.ToDo)
             .HasForeignKey(c => c.ToDoId)
             .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Priority).HasConversion<string>();
        builder.Property(x => x.Status).HasConversion<string>();

        builder.Property(t => t.RowVersion)
       .IsConcurrencyToken()
       .HasDefaultValueSql("gen_random_uuid()");

        builder.HasData(
                  new ToDo
                  {
                      Id = Guid.Parse("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
                      DateCreated = DateTime.UtcNow.ToString(),
                      DateModified = DateTime.UtcNow.ToString(),
                      CreatedBy = "seed",
                      Title = "Increase power to the warp engine",
                      DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                      DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                      Status = Status.IN_PROGRESS,
                      Priority = Priority.HIGH
                  },
                   new ToDo
                   {
                       Id = Guid.Parse("47fb53da-e324-459e-9bb5-d2dccff741d7"),
                       DateCreated = DateTime.UtcNow.ToString(),
                       DateModified = DateTime.UtcNow.ToString(),
                       CreatedBy = "seed",
                       Title = "Task1",
                       DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                       DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
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
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("f5fee937-1a62-4c00-b1ee-fbcbeff1c8d9"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task8",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("b4c862a8-4259-460d-a39e-d000df86f064"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task9",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("b8647a3b-0711-4210-8397-d77376005a81"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task10",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("562ed64a-2eac-4a12-83e9-5a7b9a32994f"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task11",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("8daa8a57-fa0d-411e-9c8a-7ce7e657d4a9"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task12",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("b7a41bb7-a2af-40fd-9f24-f1f31075760a"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task13",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("9d7cfd09-f7bc-4333-9936-7afa35f441d1"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task14",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("463ee6e5-a64a-4af5-b3c9-cc6915935784"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task15",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("ea545c41-9030-4cff-ac92-ba7753beb98d"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task16",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("e28821d5-c960-459a-9055-98e520d9b24b"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task17",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("33f8daeb-192b-4253-8e6d-d075aaf110a6"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task18",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("80bda57f-b222-405b-a1d5-59e3e8f3317c"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task19",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("f450674b-12b3-458d-bb17-b30467a2d083"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task20",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("78c897ad-b438-4b30-8781-faf82f66e819"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task21",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("ce4b4e99-017f-4ce8-8b1f-39d9289690e4"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task22",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("3fd41d79-582c-493a-a769-77cf6b0469b0"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task23",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("e9e1bd12-2165-45ac-8824-0dd47ac0755f"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task24",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("efa3a555-8c33-4106-8292-602d933bbb95"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task25",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("38f30e6c-d554-43f1-b65b-49ed08fba319"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task26",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("13c5d63b-a320-46b0-b3e5-7d205cfb7814"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task27",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("909cb444-d959-45a4-b9b7-8503b061887f"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task28",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("1797096f-fc95-4d78-9002-0976acdb6b31"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task29",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("61497cf4-db7d-45f1-8a3d-7d9f5546b4a5"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task30",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("b820cbd7-3c30-4ecc-b72a-e00351799414"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task31",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("d1776d57-d568-4058-9f14-f3522ff9db09"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task32",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("22c7b843-819d-4d3a-879d-891c86d271ef"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task33",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("b72f8cb0-6dfc-4681-90d4-4c4a9b344935"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task34",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("64452277-77ea-4087-bb50-b00bad7b8a12"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task35",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("87df559c-cc00-4aec-af3e-51a8a3f49cbc"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task36",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("d3fae83c-042c-438e-8cda-fc988de90130"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task37",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("7e93a6c4-cbf7-4873-af17-3d133194c17d"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task38",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("a544266b-a461-4d33-b426-01b540181617"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task39",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("1dbd2445-9be3-496b-9f1d-02a093adcd78"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task40",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("1ac1c57f-0754-4439-8366-f67c3c8d2770"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task41",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("28d4e06a-a868-4524-b8d7-186ce0f40506"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task42",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("dd166506-798b-4304-b988-f7c90494c3c4"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task43",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("bd5bec0a-d954-4d04-99aa-17bbd003a712"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task44",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("8a75e858-f606-4bca-8e07-a02ae2fafe20"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task45",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("f453ff36-067b-45f9-9c46-4c312495166a"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task46",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("9da798a1-3e6f-4183-81af-be347451ab77"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task47",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("792910e4-f88b-4971-9766-246a5bac736c"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task48",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("a553ddf9-eccd-4723-9d33-6e3e1045909b"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task49",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                        new ToDo
                        {
                            Id = Guid.Parse("584a8ae5-d4cb-4f82-9252-b3fca8e53ce7"),
                            DateCreated = DateTime.UtcNow.ToString(),
                            DateModified = DateTime.UtcNow.ToString(),
                            CreatedBy = "seed",
                            Title = "Task50",
                            DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                            DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                            Status = Status.TO_DO,
                            Priority = Priority.MED
                        },
                    new ToDo
                    {
                        Id = Guid.Parse("3c83b113-7134-4e9a-9b22-1a953367a426"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task51",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW
                    },
                    new ToDo
                    {
                        Id = Guid.Parse("679829ad-fc67-42d0-9d9f-533b7eeacc6f"),
                        DateCreated = DateTime.UtcNow.ToString(),
                        DateModified = DateTime.UtcNow.ToString(),
                        CreatedBy = "seed",
                        Title = "Task52",
                        DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                        DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                        Status = Status.TO_DO,
                        Priority = Priority.LOW,
                    },
                     new ToDo
                     {
                         Id = Guid.Parse("919b1e72-b78e-4cb9-8978-a65a39ed21b6"),
                         DateCreated = DateTime.UtcNow.ToString(),
                         DateModified = DateTime.UtcNow.ToString(),
                         CreatedBy = "seed",
                         Title = "Task53",
                         DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                         DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                         Status = Status.TO_DO,
                         Priority = Priority.LOW,
                     },
                      new ToDo
                      {
                          Id = Guid.Parse("551a6e50-f9a7-4c79-86ec-e84edb7ec4ad"),
                          DateCreated = DateTime.UtcNow.ToString(),
                          DateModified = DateTime.UtcNow.ToString(),
                          CreatedBy = "seed",
                          Title = "Task54",
                          DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                          DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                          Status = Status.TO_DO,
                          Priority = Priority.LOW,
                      },
                       new ToDo
                       {
                           Id = Guid.Parse("6bdcb1f6-bfce-462b-afe2-8332a524399a"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task55",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       },
                       new ToDo
                       {
                           Id = Guid.Parse("4a6310f0-c348-40f5-a78a-a213855c75fc"),
                           DateCreated = DateTime.UtcNow.ToString(),
                           DateModified = DateTime.UtcNow.ToString(),
                           CreatedBy = "seed",
                           Title = "Task56",
                           DateStart = DateOnly.FromDateTime(DateTime.UtcNow).ToString(),
                           DateEnd = DateTime.UtcNow.AddMonths(1).ToString(),
                           Status = Status.TO_DO,
                           Priority = Priority.LOW,
                       }
              );
    }
}
