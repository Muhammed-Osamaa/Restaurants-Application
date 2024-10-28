
using MediatR;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivary { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
}
