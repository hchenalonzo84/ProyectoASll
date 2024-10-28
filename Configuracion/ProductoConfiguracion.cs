using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoASll.Models;

namespace ProyectoASll.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<MProducto>
    {
        public void Configure(EntityTypeBuilder<MProducto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.NumeroSerie).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImagenURL).HasMaxLength(255);
            builder.Property(x => x.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.ModeloId).IsRequired();
            builder.Property(x => x.MarcaId).IsRequired();
            builder.Property(x => x.Disponible).IsRequired();

            // Configuración de las relaciones
            builder.HasOne(x => x.Modelo).WithMany()
                .HasForeignKey(x => x.ModeloId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Marca).WithMany()
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
