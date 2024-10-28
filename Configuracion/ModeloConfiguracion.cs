using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoASll.Models;

namespace ProyectoASll.Configuracion
{
    public class ModeloConfiguracion : IEntityTypeConfiguration<MModelos>
    {
        public void Configure(EntityTypeBuilder<MModelos> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion);
            builder.Property(x => x.SubCategoriaId).IsRequired(); // Llave foránea
            //crear las relaciones entre categoria y producto, atraves del categoriaid
            builder.HasOne(x => x.SubCategoria).WithMany()
                .HasForeignKey(x => x.SubCategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
