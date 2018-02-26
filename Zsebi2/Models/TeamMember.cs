using System.ComponentModel.DataAnnotations.Schema;

namespace Zsebi2.Models
{
    [Table("Team")]
    public class TeamMember
    {
		[Column("id")]
        public int Id { get; set; }

		[Column("name")]
        public string Name { get; set; }

		[Column("post")]
        public string Post { get; set; }

		[Column("email")]
        public string Email { get; set; }

		[Column("status")]
        public string Status { get; set; }

		[Column("image")]
        public string Image { get; set; }

		[Column("callsign")]
        public string CallSign { get; set; }

		[Column("system")]
        public string System { get; set; }

		[Column("subsystem")]
        public string SubSystem { get; set; }
    }
}

