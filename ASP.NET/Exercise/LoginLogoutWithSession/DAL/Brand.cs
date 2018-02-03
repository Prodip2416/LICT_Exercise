using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
   public sealed class Brand : MyBase, IDatabase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public  bool Insert()
        {
            Command = CommandBuilder("insert into Brand ( name, description) values (@name, @description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);

            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Brand set name=@name, description=@description where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public  bool Delete()
        {
            Command = CommandBuilder("delete from Brand where id=@id");
            Command.Parameters.AddWithValue("@id",Id);
            return ExecuteNQ(Command);
        }

        public  bool SelectById()
        {
            Command = CommandBuilder("select id, name, description from Brand where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Name = Reader["description"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder("select id, name, description from Brand where id>0 ");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += @" and (name like @search or description like @search)";
                Command.Parameters.AddWithValue("@search", "%"+Search+"%");
            }
            return ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Brand ( id int identity primary key,
                                       name varchar(20) unique, [description] varchar(50))");
            return ExecuteNQ(Command);
        }
    }
}
