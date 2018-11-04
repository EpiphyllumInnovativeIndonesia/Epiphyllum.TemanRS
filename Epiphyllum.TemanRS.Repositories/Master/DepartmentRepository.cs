using Epiphyllum.TemanRS.Models;

namespace Epiphyllum.TemanRS.Repositories.Master
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContext context) : base(context)
        {
        }
    }
}
