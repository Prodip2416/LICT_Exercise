using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Category : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } 


        public  bool Insert()
        {         
            string param = "";
            string field = "";
            Command = CommandBuilder("");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            if (CategoryId > 0)
            {
                param = ",@categoryId";
                field = ", categoryId";
                Command.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            Command.CommandText=String.Format("insert into Category ( name, description{0}) values ( @name, @description{1})", field, param);
            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Category set name=@name, description=@description where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool Delete()
        {
            Command = CommandBuilder("delete from Category where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool SelectById()
        {
            Command = CommandBuilder("select id, name, description from Category where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL="")
        {

          return  ExecuteDS(@"select c.Id, c.name, c.description, c1.name as category
                                from Category as c
                                left join Category as c1 on c.categoryId=c1.id" + ExtraSQL);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Category ( id int identity primary key,
                                 name varchar(200), [description] varchar(500)), categoryId int,
                                foreign key (categoryId) references Category(id)");
            return ExecuteNQ(Command);
        }
    }
}
