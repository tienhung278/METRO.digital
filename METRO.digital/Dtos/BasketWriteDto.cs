using System.ComponentModel.DataAnnotations;

namespace METRO.digital.Dtos;

public class BasketWriteDto
{
    public string? Customer { get; set; }
    
    public bool PaysVat { get; set; }
    
    public string? Status { get; set; }
}