namespace ApiProjeKamp.WebUI.DTOs.EventDTOs
{
    public class CreateEventDTO
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
