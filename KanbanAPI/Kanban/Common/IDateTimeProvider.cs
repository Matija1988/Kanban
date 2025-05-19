namespace Common;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }

    public DateTime Now { get; }
}
