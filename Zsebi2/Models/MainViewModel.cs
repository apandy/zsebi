using System.Collections.Generic;

namespace Zsebi2.Models
{
    public class MainViewModel
	{
		public TeamViewModel Team { get; set; }
	}

	public class TeamViewModel
	{
		public List<SubSystem> SubSystems { get;set;}
	}
	public class SubSystem
	{
		public string Name { get; set; }
		public string SystemName { get; set; }
		public List<TeamMember> Members { get; set; }
	}

	public class TeamMember
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Post { get; set; }
		public string Email { get; set; }
		public string Status { get; set; }
		public string Image { get; set; }
		public string CallSign { get; set; }
		public string System{ get; set; }
		public string SubSystem { get; set; }
	}
}

