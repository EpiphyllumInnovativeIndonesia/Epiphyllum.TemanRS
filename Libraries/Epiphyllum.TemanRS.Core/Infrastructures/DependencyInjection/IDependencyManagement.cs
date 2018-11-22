using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Core.Infrastructures.DependencyInjection
{
    public partial interface IDependencyManagement
    {
        IServiceCollection ConfigureDependency(IServiceCollection services);
    }
}
