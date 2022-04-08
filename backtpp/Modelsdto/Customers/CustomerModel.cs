namespace backtpp.Modelsdtos.Customer
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public long Cuit { get; set; }
        public string Responsabilidad { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Saldo { get; set; }

        #region paginacion
        public int Pagina { get; set; }
        public int Registros { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPages { get; set; }
        public bool IsDeleting { get; set; }

        #endregion

    }
}
