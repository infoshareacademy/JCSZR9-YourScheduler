using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleBusinessLogic
{
    public class Team
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Guid> Members { get; set; }
        public Team ()
        {
            Members = new List<Guid> ();
            Name= string.Empty;
        }
        public Team (string name, List <Guid> members)
        {
            Members = members;
            Name = name;
        }
    }
}
