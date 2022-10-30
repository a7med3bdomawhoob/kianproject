using AutoMapper;
using DAL.Entities;
using kianapi.Dtos;

namespace kianapi.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
