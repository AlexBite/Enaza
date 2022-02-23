using Enaza.Models;
using Microsoft.EntityFrameworkCore;

namespace Enaza.Contexts
{
	public sealed class UsersContext : DbContext
	{
		public UsersContext(DbContextOptions<UsersContext> options) : base(options)
		{
		}

		public DbSet<UserModel> Users { get; set; }
		public DbSet<UserGroupModel> UserGroups { get; set; }
		public DbSet<UserStateModel> UserStates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserModel>()
				.HasIndex(u => u.Login)
				.IsUnique();
		}
	}
}