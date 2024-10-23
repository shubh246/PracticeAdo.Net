using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string Name {  get; set; }
    }
}
