using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Trip_Expense_Tracker.Models.EFModels
{
	public partial class MyDbContext : DbContext
	{
		public MyDbContext()
			: base("name=MyDbContext")
		{
		}

		public virtual DbSet<budget> budgets { get; set; }
		public virtual DbSet<expense> expenses { get; set; }
		public virtual DbSet<transaction> transactions { get; set; }
		public virtual DbSet<user> users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<budget>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<expense>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.Email)
				.IsUnicode(false);
		}
	}
}
