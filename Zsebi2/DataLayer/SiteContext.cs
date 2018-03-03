using Microsoft.EntityFrameworkCore;

namespace Zsebi2.DataLayer
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
