using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class HomeViewService : IHomeViewService
    {
        private readonly IHomeViewRepository _homeViewRepository;
        private readonly IHomeViewMapper _homeViewMapper;
        public HomeViewService(IHomeViewRepository homeViewRepository,IHomeViewMapper homeViewMapper)
        {
            _homeViewRepository = homeViewRepository;
            _homeViewMapper = homeViewMapper;
        }
        public HomeViewDto GetHomeView(int id)
        {
            var homeViewFromBase=_homeViewRepository.GetDataHomeView(id);
            return _homeViewMapper.MapToHomeView(homeViewFromBase);
        }
    }
}
