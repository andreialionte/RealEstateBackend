using RealEstateBackend.Domain.Common;
using RealEstateBackend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateBackend.Domain
{
    public class Property : BaseEntity
    {
        [MaxLength(50)]
        public string? Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        /*        public string? Address { get; set; }
                public string? Contact { get; set; }
                public string? Email { get; set; }
                public string? Phone { get; set; }
                public string? Image { get; set; }*/
        public bool IsPublished { get; set; }
        public Category Category { get; set; }
        /*        public bool IsSold { get; set; }*/
        public User? User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public ICollection<Image>? Images { get; set; }
    }
}
