using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Operacion
    {
        public Operacion()
        {
            OperacionManiobras = new HashSet<OperacionManiobra>();
        }

        public long Id { get; set; }
        public DateTime Inicio { get; set; }
        public int Destino { get; set; }
        public long Cliente { get; set; }
        public int Esquema { get; set; }
        public DateTime Fin { get; set; }
        public bool Finalizada { get; set; }

        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual OpDestino DestinoNavigation { get; set; } = null!;
        public virtual Esquema EsquemaNavigation { get; set; } = null!;
        public virtual ICollection<OperacionManiobra> OperacionManiobras { get; set; }
    }
}
