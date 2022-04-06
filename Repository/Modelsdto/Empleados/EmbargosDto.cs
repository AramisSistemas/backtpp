﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelsdto.Empleados
{
    public class EmbargosDto
    {
        public long Id { get; set; }
        public long EmpleadoFk { get; set; }
        public long Cuil { get; set; }
        public string? Nombre { get; set; }
        public decimal Monto { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
        public DateTime Fin { get; set; }
        public string Concepto { get; set; } = null!;
        public string? Operador { get; set; } 
    }
}
