using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public abstract class MyBase
    {
        protected SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        private int _lastId;
        public string Error { get; set; }
        public string Search { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool DateSearch { get; set; }    
        protected bool Connection()
        {
            if (Reader != null && !Reader.IsClosed)
                return true;
            if (Cn.State == ConnectionState.Open)
                return true;
            try
            {
                Cn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return false;
        }

        protected SqlDataReader Reader;

        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            Connection() ;
            return cmd.ExecuteReader();
        }
        protected SqlCommand Command { get; set; }

        public int LastId
        {
            get
            {
                return _lastId;
            }

            set
            {
                _lastId = value;
            }
        }

        protected SqlCommand CommandBuilder(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cn;
            cmd.CommandText = SQL;
            return cmd;
        }

        protected DataSet ExecuteDs(string SQL)
        {
            DataSet ds = new DataSet();
            if (!Connection())
                return ds;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cn;
            cmd.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

         protected DataSet ExecuteDs(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            if (!Connection())
                return ds;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        protected bool ExecuteNq(SqlCommand cmd)
        {
            if (!Connection())
                return false;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return false;
        }

        protected bool ExecuteScaler(SqlCommand cmd)
        {
            if (!Connection())
                return false;
            try
            {
                LastId = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return false;
        }


    }
}
