namespace InovasysTask.Models;

public class AddressApiModel
{
    public string Street { get; set; } = string.Empty;

    public string Suite {  get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Zipcode {  get; set; } = string.Empty;

    public int UserId { get; set; }

    public virtual GeoApiModel Geo { get; set; } = null!;
}
