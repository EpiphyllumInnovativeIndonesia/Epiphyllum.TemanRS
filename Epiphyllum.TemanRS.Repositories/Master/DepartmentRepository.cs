using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories.Master
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IRepository<Department, TemanRSContext> _repository;

        public DepartmentRepository(IRepository<Department, TemanRSContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> SelectAll()
        {
            return await _repository.SelectAll();
        }

        public async Task<Department> SelectById(int id)
        {
            return await _repository.Select(where => where.Id.Equals(id));
        }

        public async Task Insert(Department department)
        {
            department.CreatedBy = "SYSTEM";
            department.CreatedTime = DateTime.Now;
            await _repository.Insert(department);
            await _repository.Save();
        }

        public async Task Update(Department department)
        {
            department.ModifiedBy = "SYSTEM";
            department.ModifiedTime = DateTime.Now;
            await _repository.Update(department);
            await _repository.Save();
        }

        public async Task Delete(int id)
        {
            Department department = await _repository.Select(where => where.Id.Equals(id));
            department.IsDeleted = true;
            department.ModifiedBy = "SYSTEM";
            department.ModifiedTime = DateTime.Now;
            await _repository.Update(department);
            await _repository.Save();
        }

        public async Task SaveChanges()
        {
            try
            {
                await _repository.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
