namespace Core.Entities;

public class BasketItem
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Publisher { get; set; }
    public ICollection<string> Genres { get; set; } = [];
    public ICollection<string> Authors { get; set; } = [];
    
}