using Microsoft.EntityFrameworkCore;
using VideoClub_API.Domain.Entities;

namespace VideoClub_API.Persistence.Contexts;

public class VideoClubDbContext(DbContextOptions<VideoClubDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });
    }
}