using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Mapppers;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddScoped<ITeamService, TeamService>();
            serviceCollection.AddScoped<IApplicationUserTeamService, ApplicationUserTeamService>();
            serviceCollection.AddScoped<IUserMapper, UserMapper>();
            serviceCollection.AddScoped<IEventMapper, EventMapper>();
            serviceCollection.AddScoped<ITeamMapper, TeamMapper>();
            serviceCollection.AddScoped<IHomeViewService, HomeViewService>();
            serviceCollection.AddScoped<IHomeViewMapper, HomeViewMapper>();
            serviceCollection.AddScoped<IAvailableTeamsViewService, AvailableTeamsViewService>();
            
        }
    }
}
