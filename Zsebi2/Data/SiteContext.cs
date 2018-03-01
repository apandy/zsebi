using Microsoft.EntityFrameworkCore;
using Zsebi2.Models;

namespace Zsebi2.Data
{
    public class SiteContext : DbContext
	{
		public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
		}

	    public DbSet<Article> Articles => Set<Article>();
		public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        
	}
    
}
