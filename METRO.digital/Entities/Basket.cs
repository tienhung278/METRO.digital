namespace METRO.digital.Models;

public class Basket
{
    public long Id { get; set; }

    public string? Customer { get; set; }
    
    public bool PaysVat { get; set; }

    public string? Status { get; set; }
    
    public ICollection<ArtIcle>? Articles { get; set; }
}