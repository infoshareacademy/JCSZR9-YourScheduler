using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleBusinessLogic
{
    public class TeamService
    {
        public List<Team> teamList = CSVManager.GetTeams();

        public void AddNewTeam(Team team)
        {
            teamList.Add(team);
        }
    }
}
