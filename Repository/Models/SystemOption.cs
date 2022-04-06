using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class SystemOption
    {
        public long X { get; set; }
        public long R { get; set; }
        public long O { get; set; }
        public string Cuit { get; set; } = null!;
        public string Razon { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public byte[]? Logo { get; set; }
        public string? Contacto { get; set; }
    }
}
