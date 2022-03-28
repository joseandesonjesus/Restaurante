using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProjectFood.Domain;
using ProjectFood.Domain.Identity;

namespace ProjectFood.Persistence.Contexts
{
    public class ProjectFoodContext : IdentityDbContext<User, Role, int,
                                    IdentityUserClaim<int>, UserRole,
                                    IdentityUserLogin<int>, IdentityRoleClaim<int>,
                                    IdentityUserToken<int>>
    {
        public ProjectFoodContext(DbContextOptions<ProjectFoodContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(m => m.Id).HasMaxLength(110);
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(m => m.Id).HasMaxLength(200);
                entity.Property(m => m.Name).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(r => r.UserId);
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.RoleId).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                entity.Property(m => m.UserId).HasMaxLength(110);
                entity.Property(m => m.LoginProvider).HasMaxLength(110);
                entity.Property(m => m.Name).HasMaxLength(110);

            });

            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                    userRole.HasOne(ur => ur.Role)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();

                    userRole.HasOne(ur => ur.User)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();
                }
            );


            modelBuilder.Entity<ProductCategory>()
            .HasKey(PE => new { PE.productId, PE.categoryId });

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Category)
            .WithOne(rs => rs.Product)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }

}