using RealEstateBackend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateBackend.Domain
{
    public class Image : BaseEntity
    {
        [MaxLength]
        public string? Url { get; set; }
        public Property? Property { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
    }
}
