using RealEstateBackend.Domain.Common;
using RealEstateBackend.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RealEstateBackend.Domain
{
    public class User : BaseEntity
    {
        /*        public int UserId { get; set; }*/
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [MaxLength(20)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        /*        public string Password { get; set; }*/
        [MaxLength(30)]
        public string? PhoneNumber { get; set; }
        [MaxLength]
        public string? Address { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(20)]
        public string? PostalCode { get; set; }
        public Role? Role { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Property>? Properties { get; set; }
        /*        public string Token { get; set; }*/
        /*        public string RefreshToken { get; set; }*/
        /*        public string PasswordHash { get; set; }
                public string PasswordSalt { get; set; }*/
    }
}
