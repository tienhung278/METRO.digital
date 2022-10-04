namespace METRO.digital.Models;

public class ArtIcle
{
    public long Id { get; set; }
    
    public string? Article { get; set; }
    
    public double Price { get; set; }
    public long BasketId { get; set; }
}