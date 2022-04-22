using System;
using System.Collections.Generic;

namespace backtpp.Models
{
    public partial class Turno
    {
        public Turno()
        {
            OperacionManiobras = new HashSet<OperacionManiobra>();
        }

        public int Id { get; set; }
        public string Horario { get; set; } = null!;
        public int Esquema { get; set; }
        public bool Nocturnidad { get; set; }
        public bool Inhabil { get; set; }

        public virtual Esquema EsquemaNavigation { get; set; } = null!;
        public virtual ICollection<OperacionManiobra> OperacionManiobras { get; set; }
    }
}
