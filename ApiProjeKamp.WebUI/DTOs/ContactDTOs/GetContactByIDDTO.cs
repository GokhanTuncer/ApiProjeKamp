namespace ApiProjeKamp.WebUI.DTOs.ContactDTOs
{
    public class GetContactByIDDTO
    {
        public int ContactID { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}
