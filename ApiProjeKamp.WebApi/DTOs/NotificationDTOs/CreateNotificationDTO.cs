namespace ApiProjeKamp.WebApi.DTOs.NotificationDTOs
{
    public class CreateNotificationDTO
    {
        
        public string Description { get; set; }
        public string IconURL { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
