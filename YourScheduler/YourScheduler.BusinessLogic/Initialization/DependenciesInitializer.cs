using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Mapppers;
using YourScheduler.BusinessLogic.Services;

namespace YourScheduler.BusinessLogic.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddScoped<IApplicationUserEventService, ApplicationUserEventService>();
            serviceCollection.AddScoped<ITeamService, TeamService>();
            serviceCollection.AddScoped<IApplicationUserTeamService, ApplicationUserTeamService>();
            serviceCollection.AddScoped<IUserMapper, UserMapper>();
            serviceCollection.AddScoped<IEventMapper, EventMapper>();
            serviceCollection.AddScoped<ITeamMapper, TeamMapper>();
;
        }
    }
}
