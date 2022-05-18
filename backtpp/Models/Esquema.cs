using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class Esquema
    {
        public Esquema()
        {
            OpComposicions = new HashSet<OpComposicion>();
            Operacions = new HashSet<Operacion>();
            Turnos = new HashSet<Turno>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;
        public int Puerto { get; set; }

        public virtual OpPuerto PuertoNavigation { get; set; } = null!;
        public virtual ICollection<OpComposicion> OpComposicions { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
