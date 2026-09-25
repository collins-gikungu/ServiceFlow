namespace ServiceFlow.API.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}