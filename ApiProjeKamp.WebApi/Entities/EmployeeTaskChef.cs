using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjeKamp.WebApi.Entities
{
    public class EmployeeTaskChef
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("EmployeeTask")]
        public int EmployeeTaskID { get; set; }
        public EmployeeTask EmployeeTask { get; set; }

        [ForeignKey("Chef")]
        public int ChefID { get; set; }
        public Chef Chef { get; set; }
    }
}
