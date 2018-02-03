using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
      public class City : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public  bool Insert()
        {
            Command = CommandBuilder("insert into City ( name, countryId) values ( @name, @countryId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update City set name=@name, countryId=@countryId where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool Delete()
        {
            Command = CommandBuilder("delete from City where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool SelectById()
        {
            Command = CommandBuilder("select id, name, countryId from City where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                CountryId = Convert.ToInt32(Reader["countryId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select City.id, City.name, Country.name as country from City 
                                left join Country on City.countryId=Country.id where city.id >0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += @" and  ( City.name like @search)";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (CountryId > 0)
            {
                Command.CommandText += @" and  (Country.id like @coutry)";
                Command.Parameters.AddWithValue("@coutry", "%" + CountryId + "%");
            }
          return  ExecuteDS(Command);

        }
        public DataSet SelectCountry()
        {
            Command = CommandBuilder("select id, name from City ");

            if (CountryId > 0)
            {
                Command.CommandText += "where countryId =@countryId";
                Command.Parameters.AddWithValue("@countryId", CountryId);
            }
            return ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table City(id int identity primary key, name varchar(200) not null, 
                                       countryId int not null, foregin key(countryId) references Country(Id))");
            return ExecuteNQ(Command);
        }
    }
}
