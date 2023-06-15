using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public class HomeViewMapper : IHomeViewMapper
    {
        public HomeViewDto MapToHomeView(HomeView homeView)
        {
            HomeViewDto homeViewDto = new HomeViewDto()
            {
               Id =homeView.HomeViewId,
               GeneralInfo=homeView.GeneralInfo,
               ImgPath=homeView.ImgPath,
            };

            return homeViewDto;
        }
    }
}
