using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Entities
{
    public class HomeView
    {
        [DisplayName("Id")]
        public int HomeViewId { get; set; }
        public string GeneralInfo { get; set; }
        public string ImgPath { get; set; }
    }
}
