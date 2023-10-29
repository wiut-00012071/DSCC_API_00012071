
using System.ComponentModel.DataAnnotations;

namespace DSCC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string JobTitle { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }
        
        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(300)]
        public string Bio { get; set; }
    }
}
