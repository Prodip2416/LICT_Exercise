using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetCRUDApplication.DAL
{
    class MyBase
    {
        protected SqlConnection cn = new SqlConnection("Data Source=AUSHOMAPTO\\SQLEXPRESS;Initial Catalog=LICT;Integrated Security=True");

        public string Error { get; set; }
        protected bool Connection()
        {
            if (cn.State == ConnectionState.Open)
                return true;
            try
            {
                cn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return false;
        }

        protected bool ExecuteNQ(SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            cn.Close();
            return false;
        }

        protected SqlCommand Command { get; set; }

        protected SqlDataReader Reader;
        protected SqlCommand CommandBuilder(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = SQL;
            return cmd;
        }

        protected DataSet ExecuteDS(string SQL)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
}
