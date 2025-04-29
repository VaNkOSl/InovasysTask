using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static InovasysTask.Commons.EntityValidationConstants.AddressesConstants;

namespace InovasysTask.Data.Models;

public class Addresses
{
    [Key]
    public int Id { get; set; }

    [MaxLength(AddressesStreetMaxLength)]
    public string Street { get; set; } = string.Empty;

    [MaxLength(AddressesSuiteMaxLength)]
    public string Suite { get; set; } = string.Empty;

    [MaxLength(AddressesCityMaxLength)]
    public string City { get; set; } = string.Empty;

    [MaxLength(AddressesZipcodeMaxLength)]
    public string Zipcode { get; set; } = string.Empty;

    public double Lat { get; set; }

    public double Lng { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
