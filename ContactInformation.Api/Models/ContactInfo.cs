using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactInformation.Api.Models
{
    public class ContactInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [StringLength(12, MinimumLength = 10, ErrorMessage = "Social security number must be between 10 and 12 characters.")]
        [Required(ErrorMessage = "Social security number is required")]
        public string? SocialSecurityNumber { get; set; }

        [RegularExpression(@"^(\+46)?\d{9}$", ErrorMessage = "Unsupported phone number format, expected +46 followed by nine digits.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "The specified email address is not valid.")]
        public string? Email { get; set; }
    }
}
