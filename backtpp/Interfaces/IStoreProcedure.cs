using System.Data;
using System.Data.SqlClient;

namespace backtpp.Interfaces
{
    public interface IStoreProcedure
    {
        public DataTable SpWhithDataSet(string Sp, List<SqlParameter> Param = null);
        public DataSet SpWhithDataSetPure(string Sp, List<SqlParameter> Param = null);

        public bool ExecuteNonQuery(string Sp, List<SqlParameter> Param = null);

        public object ExecuteScalar(string Sp, List<SqlParameter> Param = null);

    }
}
