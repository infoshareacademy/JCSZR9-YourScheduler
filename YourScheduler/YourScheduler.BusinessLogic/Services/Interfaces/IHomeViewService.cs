using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IHomeViewService
    {
        public HomeViewDto GetHomeView(int id);  
    }
}
