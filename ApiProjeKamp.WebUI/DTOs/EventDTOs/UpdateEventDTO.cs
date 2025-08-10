namespace ApiProjeKamp.WebUI.DTOs.EventDTOs
{
    public class UpdateEventDTO
    {
        public int YummyEventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
