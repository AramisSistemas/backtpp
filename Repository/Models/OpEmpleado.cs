using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class OpEmpleado
    {
        public OpEmpleado()
        {
            Liquidacions = new HashSet<Liquidacion>();
            OpEmpleadoEmbargoes = new HashSet<OpEmpleadoEmbargo>();
        }

        public long Id { get; set; }
        public long Cuil { get; set; }
        public string Nombre { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public long Osocial { get; set; }
        public DateTime Nacimiento { get; set; }
        public bool Conyuge { get; set; }
        public int Hijos { get; set; }
        public string Cbu { get; set; } = null!;
        public long? CuilCbu { get; set; }
        public bool Activo { get; set; }
        public int? Puesto { get; set; }
        public DateTime Ingreso { get; set; }
        public string Sexo { get; set; } = null!;

        public virtual ObraSocial OsocialNavigation { get; set; } = null!;
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
        public virtual ICollection<OpEmpleadoEmbargo> OpEmpleadoEmbargoes { get; set; }
    }
}
