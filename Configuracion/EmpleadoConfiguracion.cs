using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoASll.Models;

namespace ProyectoASll.Configuracion
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<MEmpleado>
    {
        public void Configure(EntityTypeBuilder<MEmpleado> builder)
        {
            // Configurando Nombre
            builder.Property(u => u.Nombre)
                .HasMaxLength(60)  // Máximo 60 caracteres
                .IsRequired();  // Campo obligatorio

            // Configurando Apellido
            builder.Property(u => u.Apellido)
                .HasMaxLength(60)  // Máximo 60 caracteres
                .IsRequired();  // Campo obligatorio

            // Configurando Rol
            builder.Property(u => u.Rol)
                .HasMaxLength(50)  // Máximo 50 caracteres
                .IsRequired();  // Campo obligatorio

            // Configurando Número
            builder.Property(u => u.Numero)
                .HasMaxLength(15)  // Máximo 15 caracteres
                .IsRequired();  // Campo obligatorio

            // Configurando FechaDeCreacion como opcional
            builder.Property(u => u.FechaDeCreacion)
                .HasDefaultValueSql("GETDATE()")  // Valor predeterminado es la fecha actual
                .IsRequired(false);  // No es obligatorio

            // Configurando FechaDeModificacion como opcional
            builder.Property(u => u.FechaDeModificacion)
                .IsRequired(false);  // No es obligatorio, puede ser nulo
        }
    }
}
