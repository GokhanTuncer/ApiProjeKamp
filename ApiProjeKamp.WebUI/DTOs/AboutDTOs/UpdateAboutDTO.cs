namespace ApiProjeKamp.WebUI.DTOs.AboutDTOs
{
    public class UpdateAboutDTO
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string VideoCoverImageURL { get; set; }
        public string VideoURL { get; set; }
        public string ReservationNumber { get; set; }
    }
}
