using System;

namespace kianapi.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

     
        public string username { get; set; }
        public bool IsActive { get; set; }
    }
}
