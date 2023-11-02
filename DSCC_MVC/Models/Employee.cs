
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCC_MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string JobTitle { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Bio { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
