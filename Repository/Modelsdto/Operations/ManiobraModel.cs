using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Repository.Modelsdto.Operations
{
    public class ManiobraModel
    {
        public long Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Turno { get; set; }

        [Required]
        public int Maniobra { get; set; }

        public string? TurnoDesc { get; set; } = "";

        public string? ManiobraNombre { get; set; } = "";

        [Required]
        [Precision(15, 3)]
        [Range(0, 130,
        ErrorMessage = "La produccion debe estar entre {1} y {2} Tn.")]
        public decimal Produccion { get; set; }

        [Required]
        public bool Lluvia { get; set; }

        [Required]
        public bool Insalubre { get; set; }

        [Required]
        public bool Sobrepeso { get; set; }

        [Required]
        public long Operacion { get; set; }

    }
}
