using WAW.API.Shared.Domain.Model;

namespace WAW.API.Job.Domain.Models;

public class Offer : BaseModel {

    public string? Title { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public string? SalaryRange { get; set; }
    public bool Status { get; set; }
}
