using System.Collections.Generic;

namespace Zsebi2.Models
{
    public class MainViewModel
    {
        public TeamViewModel Team { get; set; }
    }

    public class TeamViewModel
    {
        public List<SubSystem> SubSystems { get; set; }
    }
    public class SubSystem
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
        public List<TeamMember> Members { get; set; }
    }
}

