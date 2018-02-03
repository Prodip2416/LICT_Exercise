using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL
{
    public class Voucher : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentNumber { get; set; }
        public Boolean AutoNumber { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public int Length { get; set; }
        public Boolean AutoPrint { get; set; }
        public string Nature { get; set; }  

        public bool Insert()
        {
            Command = CommandBuilder(@"insert into Voucher(name, description, autoNumber, currentNumber, prefix, postfix, lenght, autoPrint, nature)
                                                 values (@name, @description, @autonumber, @currentNumber, @prefix, @postfix, @length, @autoprint, @nature)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@autonumber", AutoNumber);
            Command.Parameters.AddWithValue("@currentNumber", CurrentNumber);
            Command.Parameters.AddWithValue("@prefix", Prefix);
            Command.Parameters.AddWithValue("@postfix", Postfix);
            Command.Parameters.AddWithValue("@length", Length);
            Command.Parameters.AddWithValue("@autoprint", AutoPrint);
            Command.Parameters.AddWithValue("@nature", Nature);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Voucher set name=@name, description=@description, autoNumber=@autoNumber, prefix=@preFix,
                                       currentNumber=@currentNumber, postfix=@postFix, lenght=@lenght, autoPrint=@autoPrint, nature=@nature where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@autoNumber", AutoNumber);
            Command.Parameters.AddWithValue("@currentNumber", CurrentNumber);
            Command.Parameters.AddWithValue("@prefix", Prefix);
            Command.Parameters.AddWithValue("@postfix", Postfix);
            Command.Parameters.AddWithValue("@lenght", Length);
            Command.Parameters.AddWithValue("@autoPrint", AutoPrint);
            Command.Parameters.AddWithValue("@nature", Nature);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Voucher where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder("select id, name, description, autoNumber, prefix, currentNumber, postfix, lenght, autoPrint, nature from Voucher where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                AutoNumber =Convert.ToBoolean(Reader["autoNumber"]);
                Prefix = Reader["prefix"].ToString();
                CurrentNumber = Convert.ToInt32(Reader["currentNumber"]);
                Postfix = Reader["postfix"].ToString();
                Length = Convert.ToInt32(Reader["lenght"]);
                AutoPrint = Convert.ToBoolean(Reader["autoPrint"]);
                Nature = Reader["nature"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select id, name, description, autoNumber, currentNumber, lenght,
                              prefix , postfix , autoPrint, nature
                              from Voucher where id>0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and name like @search or description like @search";
                Command.Parameters.AddWithValue("@search", Search);
            }

            if (!string.IsNullOrEmpty(Nature))
            {
                Command.CommandText += " and nature like @nature";
                Command.Parameters.AddWithValue("@nature", Nature);
            }
          return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Voucher( id int identity primary key, name varchar(200),
                                        description varchar(500), autoNumber int, prefix varchar(5), currentNumber bit,
                                        postfix varchar (5), lenght int, autoPrint bit,nature varchar(10) )");
            return ExecuteNQ(Command);
        }
    }
}
