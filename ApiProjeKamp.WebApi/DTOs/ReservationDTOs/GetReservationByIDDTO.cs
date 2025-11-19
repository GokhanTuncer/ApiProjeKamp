namespace ApiProjeKamp.WebApi.DTOs.ReservationDTOs
{
    public class GetReservationByIDDTO
    {
        public int ReservationID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int CountOfPeople { get; set; }
        public string Message { get; set; }
        public string ReservationStatus { get; set; }
    }
}
