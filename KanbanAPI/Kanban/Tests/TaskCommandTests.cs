using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Handlers.Tasks;
using Common;
using Domain.Users;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class CreateToDoIntegrationTests : IntegrationTestBase
{
    [Fact]
    public async Task CreateToDoCommand_Should_Add_Task_When_Data_Is_Valid()
    {
        // Arrange
        var dbContext = ServiceProvider.GetRequiredService<IApplicationDbContext>();

        var testUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "testuser",
            Email = "test@example.com"
        };
        dbContext.Users.Add(testUser);
        await dbContext.SaveChangesAsync();

        var mediator = ServiceProvider.GetRequiredService<IMediator>();
        var now = ServiceProvider.GetRequiredService<IDateTimeProvider>().Now;

        var command = new CreateToDoCommand(
            Title: "Test Task",
            Description: "Test Description",
            DateTimeStart: now.AddDays(1).ToString("O"),
            DateTimeEnd: now.AddDays(2).ToString("O"),
            CreatedBy: testUser.Username,
            Priority: Priority.MED,
            Status: Status.TO_DO
        );

        // Act
        var result = await mediator.Send(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeGreaterThan(0);

        var createdTask = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Title == "Test Task");
        createdTask.Should().NotBeNull();
        createdTask.CreatedBy.Should().Be("testuser");
    }
}
