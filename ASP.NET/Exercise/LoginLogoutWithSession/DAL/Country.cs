using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Country:MyBase,IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }


        public  bool Insert()
        {
            Command = CommandBuilder("insert into Country (name) values (@name)");
            Command.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Country set name=@name where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public  bool Delete()
        {
            Command = CommandBuilder("delete from Country where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public  bool SelectById()
        {
            Command = CommandBuilder("select id, name from Country where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder("select id, name from Country where id>0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
           return  ExecuteDS(Command);
        }
        public  bool Table()
        {    
            Command = CommandBuilder(@"create table Country( id int identity primary key,
                                       name varchar(200) unique not null)");
            return ExecuteNQ(Command);
        }
    }
}
