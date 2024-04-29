using RealEstateBackend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateBackend.Domain
{
    public class Review : BaseEntity
    {
        /*        public int Id { get; set; }*/
        public User? User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [MaxLength(30)]
        public string? Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
    }
}
