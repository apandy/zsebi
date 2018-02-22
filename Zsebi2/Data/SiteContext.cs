using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zsebi2.Models;

namespace Zsebi2.Data
{
    public class SiteContext : DbContext
	{
		//public SiteContext()
		//{

		//}

		public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<TeamMember> TeamMembers { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Article>().ToTable("Articles");
			modelBuilder.Entity<TeamMember>().ToTable("Team");
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	 //  => optionsBuilder
		//   .UseMySql(@"Server=localhost;database=zsebi;uid=root;pwd=admin;");
	}

	public class News
	{
		public int id { get; set; }
		public string newstitle { get; set; }
		public string newstext { get; set; }
	}
}
