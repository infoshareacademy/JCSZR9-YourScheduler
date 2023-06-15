using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Entities
{
    public class HomeView
    {
        public int HomeViewId { get; set; } 
        public string GeneralInfo { get; set; }

        public string ImgPath { get; set; } = "/Pictures/harmonogram_870x450_a.jpg";
    }
}
