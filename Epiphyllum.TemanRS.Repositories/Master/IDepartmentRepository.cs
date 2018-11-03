using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;

namespace Epiphyllum.TemanRS.Repositories.Master
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> SelectAll();
        Task<Department> SelectById(int id);
        Task Insert(Department department);
        Task Update(Department department);
        Task Delete(int id);
    }
}
