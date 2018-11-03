using System.Collections.Generic;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;
using Epiphyllum.TemanRS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epiphyllum.TemanRS.Web.Api.Controllers.Master
{
    [AllowAnonymous]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            return await _departmentRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _departmentRepository.Select(prop => prop.Id.Equals(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            await _departmentRepository.Insert(department);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department department)
        {
            await _departmentRepository.Update(department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Department department = new Department();
            await _departmentRepository.Update(department);
            return Ok();
        }
    }
}