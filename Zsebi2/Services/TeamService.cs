using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zsebi2.DataLayer;
using Zsebi2.Models;

namespace Zsebi2.Services
{
    public class TeamService : ITeamService
    {
        private readonly SiteContext _context;

        public TeamService(SiteContext context)
        {
            _context = context;
        }
        public async Task<TeamViewModel> GetTeamViewModel()
        {
            var team = await _context.TeamMembers.ToListAsync();
            var active = GetSubSystem(team, "active");
            var passive = GetSubSystem(team, "passive");
            return new TeamViewModel
            {
                Active = active,
                Passive = passive
            };

        }

        private static List<SubSystem> GetSubSystem(List<TeamMember> team, string status)
        {
            return team.Where(t => t.Status == status)
                .GroupBy(m => new { m.SubSystem, m.System })
                .Select(s => new SubSystem
                {
                    Name = s.Key.SubSystem,
                    SystemName = s.Key.System,
                    Members = s.ToList(),
                }).ToList();
        }
    }
}
