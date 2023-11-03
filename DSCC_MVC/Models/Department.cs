
using System.ComponentModel.DataAnnotations;

namespace DSCC_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";
    }
}
