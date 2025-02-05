namespace Tamirci.Entities;

public class Craftsman : AppUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public byte Raiting { get; set; }
}
