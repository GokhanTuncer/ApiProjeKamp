using System.Security.Cryptography.Pkcs;

namespace ApiProjeKamp.WebApi.Entities
{
    public class Chef
    {
        public int ChefID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public List<EmployeeTaskChef> EmployeeTaskChefs { get; set; }
    }
}
