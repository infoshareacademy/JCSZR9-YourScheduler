using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IApplicationUsersEventsRepository, ApplicationUsersEventsRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<IApplicationUsersTeamsRepository, ApplicationUsersTeamsRepository>();
            services.AddScoped<IHomeViewRepository, HomeViewRepository>();
        }
    }
}
