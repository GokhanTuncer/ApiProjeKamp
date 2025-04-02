﻿namespace ApiProjeKamp.WebApi.DTOs.MessageDTOs
{
    public class GetByIDMessageDTO
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
