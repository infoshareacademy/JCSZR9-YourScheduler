using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class HomeViewService : IHomeViewService
    {
        private readonly IHomeViewRepository _homeViewRepository;
        public HomeViewService(IHomeViewRepository homeViewRepository)
        {
            _homeViewRepository = homeViewRepository;
        }
        public HomeView GetHomeView(int id)
        {
            return _homeViewRepository.GetDataHomeView(id);
        }
    }
}
