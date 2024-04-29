using RealEstateBackend.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RealEstateBackend.Domain
{
    public class Auth : BaseEntity
    {

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
    }
}
