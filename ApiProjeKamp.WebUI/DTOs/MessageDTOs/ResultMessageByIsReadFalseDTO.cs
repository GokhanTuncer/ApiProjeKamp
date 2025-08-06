﻿namespace ApiProjeKamp.WebUI.DTOs.MessageDTOs
{
    public class ResultMessageByIsReadFalseDTO
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
