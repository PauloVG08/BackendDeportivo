using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Models
{
    public partial class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductoId).HasName("PK__Producto__756A5402E0FFF6DD");

                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoId");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nombre");
                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Categoria");
                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnName("Precio");
                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnType("varchar(max)")
                    .HasColumnName("Imagen");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("Descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
