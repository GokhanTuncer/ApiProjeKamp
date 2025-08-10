namespace ApiProjeKamp.WebUI.DTOs.ChefDTOs
{
    public class GetChefByIDDTO
    {
        public int ChefID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
