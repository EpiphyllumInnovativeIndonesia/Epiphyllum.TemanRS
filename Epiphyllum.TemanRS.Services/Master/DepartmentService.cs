using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;
using Epiphyllum.TemanRS.Repositories.Master;
using LinqKit;

namespace Epiphyllum.TemanRS.Services.Master
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> SelectAllDepartment()
        {
            ExpressionStarter<Department> predicate = PredicateBuilder.New<Department>();
            predicate.Start(prop => !prop.IsDeleted);
            IEnumerable<Department> departments = await _departmentRepository.SelectList(predicate);
            return departments;
        }

        public async Task<Department> SelectDepartmentWithEmployee(int id)
        {
            ExpressionStarter<Department> predicate = PredicateBuilder.New<Department>();
            predicate.Start(prop => !prop.IsDeleted);
            predicate.And(prop => prop.Id.Equals(id));
            Department department = await _departmentRepository.Select(predicate, nav => nav.Employee);
            return department;
        }

        public async Task CreateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));

            department.CreatedBy = "SYSTEM";
            department.CreatedTime = DateTime.Now;
            await _departmentRepository.Insert(department);
        }

        public async Task UpdateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));

            department.ModifiedBy = "SYSTEM";
            department.ModifiedTime = DateTime.Now;
            await _departmentRepository.Update(department);
        }

        public async Task DeleteDepartment(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            ExpressionStarter<Department> predicate = PredicateBuilder.New<Department>();
            predicate.Start(prop => !prop.IsDeleted);
            predicate.And(prop => prop.Id.Equals(id));

            Department department = await _departmentRepository.Select(predicate);
            department.IsDeleted = true;
            department.ModifiedBy = "SYSTEM";
            department.ModifiedTime = DateTime.Now;
            await _departmentRepository.Update(department);
        }
    }
}
