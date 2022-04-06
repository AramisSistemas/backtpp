using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Empleados
{
    public class EmpleadoEmbargoAdd
    {
        [Required]
        public long Empleado { get; set; }
        [Required]
        [Range(100, 1000000)]
        public decimal Total { get; set; }
        [Required]
        [Range(10, 50)]
        public decimal Monto { get; set; }
        [Required]
        public string Concepto { get; set; }
        [Required]
        public DateTime FechaFin { get; set; } 
        public string Operador { get; set; }
        [Required]
        public bool Anticipo { get; set; }
    }
}
