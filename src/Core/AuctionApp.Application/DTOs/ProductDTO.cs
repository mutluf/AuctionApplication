namespace AuctionApp.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } = "https://loremflickr.com/320/240/art";
        public int BeginPrice { get; set; }
        public DateTime BeginDate { get; set; }

    }
}
