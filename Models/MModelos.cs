using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoASll.Models
{
    public class MModelos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El nombre debe ser máximo de 60 caracteres")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //propiedades para las relaciones entre los modelos y las tablas en la base de datos
        [Required(ErrorMessage = "La subcategoria es requerida")]
        public int SubCategoriaId { get; set; }
        //colocamos el modelo con el que esta relacioando
        [ForeignKey("SubCategoriaId")]
        public MSubCategoria SubCategoria { get; set; }
    }
}
