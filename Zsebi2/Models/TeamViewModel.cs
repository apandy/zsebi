using System.Collections.Generic;

namespace Zsebi2.Models
{
    public class TeamViewModel
    {
        public List<SubSystem> Active { get; set; }
        public List<SubSystem> Passive { get; set; }
    }
}