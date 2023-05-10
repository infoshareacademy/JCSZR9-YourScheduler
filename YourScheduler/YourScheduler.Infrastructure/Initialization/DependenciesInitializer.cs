
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
using YourScheduler.Infrastructure.Identity;

namespace YourScheduler.Infrastructure.Initialization
{
    public static class DependenciesInitializer
    {      
        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();

            //var connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");
            //services.AddDbContext<YourSchedulerDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
            ////services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            ////{
            ////    options.SignIn.RequireConfirmedAccount = false;
            ////    options.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
            ////    {
            ////        RequireDigit = true,
            ////        RequiredLength = 8,
            ////        RequireLowercase = true,
            ////        RequireUppercase = true,
            ////        RequireNonAlphanumeric = true,


            ////    };
            ////}).AddErrorDescriber<LocalizedIdentityErrorDescriber>().AddEntityFrameworkStores<YourSchedulerDbContext>();
            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false); //PAMI�TA� O TEJ ZMIANIE (NIE TRZEBA POTWIERDZA� MAILA TERAZ)

            //services.AddMvc();
        }
    }
}
