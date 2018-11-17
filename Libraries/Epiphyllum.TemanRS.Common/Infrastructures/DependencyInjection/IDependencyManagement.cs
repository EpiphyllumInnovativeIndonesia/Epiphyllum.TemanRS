using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Common.Infrastructures.DependencyInjection
{
    public interface IDependencyManagement
    {
        IServiceCollection ConfigureDependency(IServiceCollection services);
    }
}
