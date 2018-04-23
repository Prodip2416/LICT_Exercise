using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;

namespace RoobDAL
{
    public abstract class MyBase
    {
         // Add connection string to web.config file 
        protected MySqlConnection Cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        //some importent field....
        private int _lastId;
        public string Error { get; set; }
        public string Search { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool DateSearch { get; set; }

        // Check connection
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

        protected MySqlDataReader Reader;

        protected MySqlDataReader ExecuteReader(MySqlCommand cmd)
        {
            Connection();
            return cmd.ExecuteReader();
        }
        protected MySqlCommand Command { get; set; }

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
        // uses for commmand 
        protected MySqlCommand CommandBuilder(string SQL)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Cn;
            cmd.CommandText = SQL;
            return cmd;
        }
        // return dataset using sql query 
        protected DataSet ExecuteDs(string SQL)
        {
            DataSet ds = new DataSet();
            if (!Connection())
                return ds;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Cn;
            cmd.CommandText = SQL;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        // return dataset using command
        protected DataSet ExecuteDs(MySqlCommand cmd)
        {
            DataSet ds = new DataSet();
            if (!Connection())
                return ds;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            
            return ds;
        }
      
        // using insert, update and delete for command
        protected bool ExecuteNq(MySqlCommand cmd)
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
        // Single data return
        protected bool ExecuteScaler(MySqlCommand cmd)
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
