
using System.ComponentModel.DataAnnotations;

namespace DSCC_API_00012071.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";
    }
}
