namespace METRO.digital.Dtos;

public class BasketReadDto
{
    public long Id { get; set; }
    
    public double TotalNet
    {
        get => Articles?.Sum(a => a.Price) ?? 0;
    }

    public double TotalGross
    {
        get => PaysVat ? TotalNet + TotalNet * 0.1 : TotalNet;
    }
    
    public string? Customer { get; set; }
    
    public bool PaysVat { get; set; }
    
    public ICollection<ArticleReadDto>? Articles { get; set; }
}