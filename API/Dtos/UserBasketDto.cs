namespace API.Dtos;

public class UserBasketDto
{
    public string Id { get; set; }
    public List<BasketItemDto> Items { get; set; }
}