using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL
{
    public class Unit : MyBase, IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PrimaryQuentity { get; set; }

        public bool Insert()
        {
            Command = CommandBuilder("insert into Unit (name, description, primaryQty) values(@name, @description, @primaryQuentity)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryQuentity", PrimaryQuentity);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder("update Unit set name=@name, description=@description, primaryQty=@primaryQuentity where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryQuentity", PrimaryQuentity);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Unit where id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder("select id, name, description, primaryQty from Unit where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                PrimaryQuentity = Convert.ToDouble(Reader["primaryQty"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select id, name, description, primaryQty from Unit where id>0");
            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@" create table Unit ( id int identity Primary key, name varchar(200),
                    [description] varchar(500), primaryQty float)");
            return ExecuteNQ(Command);
        }
    }
}
