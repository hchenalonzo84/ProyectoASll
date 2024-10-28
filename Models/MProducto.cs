﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoASll.Models
{
    public class MProducto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre debe ser máximo de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El número de serie es requerido")]
        [MaxLength(100, ErrorMessage = "El numero de serie debe ser máximo de 100 caracteres")]
        public string NumeroSerie { get; set; }

        [MaxLength(255, ErrorMessage = "El nurl de la imagen debe ser máximo de 255 caracteres")]
        public string ImagenURL { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        public int ModeloId { get; set; }
        [ForeignKey("ModeloId")]
        public MModelos Modelo { get; set; }

        [Required(ErrorMessage = "La marca es requerida")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public MMarca Marca { get; set; }

        public bool Disponible { get; set; } = true; // Por defecto está disponible
    }
}
