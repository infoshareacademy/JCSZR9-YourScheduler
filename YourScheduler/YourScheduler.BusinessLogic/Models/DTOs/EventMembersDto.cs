using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.BusinessLogic.Models.DTOs
{
    public class EventMembersDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool Isopen { get; set; }

        public int administratorId { get; set; }

        public IEnumerable<UserDto> EventUsers { get; set; }
    }
}
