using AutoMapper;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using kianapi.Dtos;
using kianapi.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kianapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenaricRepository<Employee> repository;
        private readonly KianDbContext context;
        private readonly IMapper mapper;

        [HttpPost]
       public async Task<ActionResult<EmployeeDto>> addEmployeeForm(EmployeeDto employeeDto)
        {
           try
            {
                var result = new Employee()
                {
                    first_name = employeeDto.first_name,
                    last_name = employeeDto.last_name,
                    username = employeeDto.username,
                    IsActive = true,
                    DateOfBirth = DateTime.Now,
                    age = 0

                };
                await  repository.Add(result);
                await repository.SaveChanges();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);

            }
        }
        public EmployeeController(IGenaricRepository<Employee> repository, KianDbContext context, IMapper mapper)
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetAllEmployees()
        {
            var data = await repository.getallemployees();
            var response = mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeDto>>(data);
            return Ok(response);
        }
        [HttpGet("serchByid/{id}") ]
        public async Task<ActionResult<EmployeeDto> > Searching(int ? id)
        {
            var data= await repository.search(id);
            var translated= mapper.Map<Employee,EmployeeDto> (data);
            return Ok(translated);
        }
         [HttpDelete("{id}") ]
        public async Task<ActionResult<EmployeeDto> > Delete(int ? id)
        {
            var data= await repository.search(id);
            repository.Delete(data);
            await repository.SaveChanges();
            return Ok(data);
        }




        [HttpPut("{id}")]
      
        public async Task<ActionResult<Employee>> UpdateProduct(int id, Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {

                var data = await repository.search(id);
                if (data == null) return BadRequest(new ErrorHandeler(404));


                data.first_name = employee.first_name;
                data.last_name = employee.last_name;
                data.username = employee.username;
                data.IsActive = employee.IsActive;

                repository.Update(data);
               await repository.SaveChanges();


                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
