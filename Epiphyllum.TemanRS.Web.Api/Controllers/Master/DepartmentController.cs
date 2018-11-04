using System.Collections.Generic;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;
using Epiphyllum.TemanRS.Repositories;
using Epiphyllum.TemanRS.Services.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epiphyllum.TemanRS.Web.Api.Controllers.Master
{
    [AllowAnonymous]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IRepository<Department> departmentRepository,
            IDepartmentService departmentService)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            return await _departmentService.SelectAllDepartment();
        }

        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _departmentService.SelectDepartmentWithEmployee(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            await _departmentService.CreateDepartment(department);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            await _departmentService.UpdateDepartment(department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}