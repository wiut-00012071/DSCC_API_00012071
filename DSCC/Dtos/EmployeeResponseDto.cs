using DSCC.Models;

namespace DSCC.Dtos
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string JobTitle { get; set; } = "";

        public string Bio { get; set; } = "";

        public static EmployeeResponseDto MapFromEmployee( Employee employee )
        {
            return new EmployeeResponseDto() { 
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                Bio = employee.Bio
            };
        }
    }
}
