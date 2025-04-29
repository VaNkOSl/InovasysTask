using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static InovasysTask.Commons.EntityValidationConstants.UsersConstants;

namespace InovasysTask.Data.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(UsersNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(NotUsernameMaxLength)]
    [Column("Not Username")]
    public string NotUsername { get; set; } = string.Empty;

    [MaxLength(UsersEmailMaxLength)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(UsersPhoneMaxLength)]
    public string Phone { get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}