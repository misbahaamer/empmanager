using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Infrastructure.Persistance;
using Task.Infrastructure.Repositories;

namespace Task.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeBenefitRepository, EmployeeBenefitRepository>();
            services.AddScoped<IDependentRepository, DependentRepository>();
            services.AddScoped<IPayrollRepository   , PayrollRepository>();



            return services;
        }
    }
}
