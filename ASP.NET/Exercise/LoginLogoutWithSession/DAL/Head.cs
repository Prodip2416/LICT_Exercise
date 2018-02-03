using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public  class Head : MyBase,IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; } 


        public  bool Insert()
        {
            string param = "";
            string field = "";
            Command = CommandBuilder("");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);

            if (HeadId > 0)
            {
                param = ",@headId";
                field = ",headId";
                Command.Parameters.AddWithValue("@headId", HeadId);
            }

            Command.CommandText=String.Format("insert into Head (name, description{0}) values (@name, @description{1})", field, param);
            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Head set name=@name, description=@description, headId=@headId where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public  bool Delete()
        {
            Command = CommandBuilder("delete from Head where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            Command = CommandBuilder("select name, description, headId from Head where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                HeadId = Convert.ToInt32(Reader["headId"]);
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL="")
        {
           return  ExecuteDS(@"select h1.Id, h1.name, h1.description, h2.Name as head
                                from Head as h1
                                left join Head as h2 on h1.headId=h2.id "+ExtraSQL);
        }
        public  bool Table()
        {    
            Command = CommandBuilder(@"create table Head(id int identity(1,1) primary key,
                                        name varchar(200) unique, [description] varchar(500),
                                        headId int, foreign key(headId) references Head(id))");
            return ExecuteNQ(Command);
        }
    }
}
