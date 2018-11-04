using System.Collections.Generic;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Models;

namespace Epiphyllum.TemanRS.Services.Master
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> SelectAllDepartment();
        Task<Department> SelectDepartmentWithEmployee(int id);
        Task CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
    }
}
