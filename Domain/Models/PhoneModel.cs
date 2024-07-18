namespace Domain.Models;

public class PhoneModel : BaseEntity
{
    public string? PhoneName { get; set; }
    public string? Company { get; set; }
    public int Price { get; set; }
    public int ProductYear { get; set; }
}