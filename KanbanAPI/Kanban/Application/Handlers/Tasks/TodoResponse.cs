namespace Application.Handlers.Tasks;

public sealed record TodoResponse
{
    public Guid Id { get; set; }
    public string DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public string? DateModified { get; set; }
    public string? ModifiedBy { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool isInProgress { get; set; }
    public string DateStart { get; set; }
    public string DateEnd { get; set; }

    public string Priority { get; set; }
    public string Status { get; set; }
    public string? RowVersion { get; set; }

    public List<Link> Links { get; set; } = new();

    public List<CommentResponse>? Comments { get; set; }

    public List<UserResponse>? Users { get; set; }
}

