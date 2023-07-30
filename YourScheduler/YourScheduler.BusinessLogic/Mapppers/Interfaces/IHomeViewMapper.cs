using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers.Interfaces
{
    public interface IHomeViewMapper
    {
        HomeViewDto MapToHomeView(HomeView homeView);
    }
}
