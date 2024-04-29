using RealEstateBackend.Domain.Enums;

namespace RealEstateBackend.Application.Features.Property.Queries.GetProperties
{
    public class PropertyDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        /*        public string? Address { get; set; }
                public string? Contact { get; set; }
                public string? Email { get; set; }
                public string? Phone { get; set; }
                public string? Image { get; set; }*/
        public bool IsPublished { get; set; }
        public Category Category { get; set; }
    }
}
