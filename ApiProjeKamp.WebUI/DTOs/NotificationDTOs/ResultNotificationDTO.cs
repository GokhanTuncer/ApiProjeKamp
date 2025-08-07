namespace ApiProjeKamp.WebUI.DTOs.NotificationDTOs
{
    public class ResultNotificationDTO
    {
        public int NotificationID { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
