using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoASll.Models;

namespace ProyectoASll.Configuracion
{
    public class CategoriaConfiguracion : IEntityTypeConfiguration<MCategoria>
    {
        public void Configure(EntityTypeBuilder<MCategoria> builder)
        {
            //agregar las propiedades del modelo categoria 1 x 1 para realizar el override y la aplicacion de fluent API
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion);
        }
    }
}
