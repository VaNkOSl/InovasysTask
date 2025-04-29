namespace InovasysTask.Models;

public class UserViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; }  = string.Empty;

    public string Phone {  get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public string Note {  get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsActive { get; set; }

    public virtual AddressApiModel Address { get; set; } = null!;
}
