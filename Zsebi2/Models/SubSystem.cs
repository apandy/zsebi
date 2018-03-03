using System.Collections.Generic;
using Zsebi2.DataLayer;

namespace Zsebi2.Models
{
    public class SubSystem
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
        public List<TeamMember> Members { get; set; }
    }
}