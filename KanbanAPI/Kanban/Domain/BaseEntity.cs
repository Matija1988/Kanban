using Common;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public abstract class BaseEntity : Entity
{
    public Guid Id { get; set; }

    [StringLength(30)]
    public string DateCreated { get; set; }

    [StringLength(30)]
    public string? DateModified { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    public string? ModifiedBy { get; set; }
}
