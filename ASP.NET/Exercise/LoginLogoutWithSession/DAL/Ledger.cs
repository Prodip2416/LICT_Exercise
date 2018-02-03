using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Ledger : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public int HeadId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public DateTime CreateDate { get; set; }
        public int EmployeeId { get; set; }


        public bool Insert()
        {
            string param = "";
            string field = "";

            Command = CommandBuilder(@"");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", Contact);
            Command.Parameters.AddWithValue("@contactPerson", ContactPerson);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@cityId", CityId);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            if (EmployeeId > 0)
            {
                param = ", @employeeId";
                field = ", employeeId";
                Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            }

            Command.CommandText=String.Format(@"insert into Ledger( name, contact, contactPerson, email, password, headId, description, address,
                                      cityId, countryId, createDate{0})
                                     values(@name, @contact, @contactPerson, @email, @password, @headId,
                                     @description, @address, @cityId, @countryId, @createDate{1})", field, param);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Ledger set name = @name, contact=@contact, contactPerson=@contactPerson,
                                    email=@email, password=@password, headId=@headId, description=@description,
                                    address=@address, cityId=@cityId, createDate=@createDate, employeeId=@employeeId 
                                    id = @id");


            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", Contact);
            Command.Parameters.AddWithValue("@contactPerson", ContactPerson);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);
            Command.Parameters.AddWithValue("@headId", HeadId);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@cityId", CityId);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Ledger where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select id, name, contact, contactPerson, email, password, headId, description, address," +
                                     " cityId, createDate, employeeId from Ledger where id=@id");
            Command.Parameters.AddWithValue("@id",Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Contact = Reader["contact"].ToString();
                ContactPerson = Reader["contactPerson"].ToString();
                Email = Reader["email"].ToString();
                Password = Reader["password"].ToString();
                HeadId = Convert.ToInt32(Reader["headId"]);
                Description = Reader["description"].ToString();
                Address = Reader["address"].ToString();
                CityId =Convert.ToInt32(Reader["cityId"]);
                CreateDate = (DateTime)Reader["creatDate"];
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                return true;
            }
            return false;
        }
        public bool Login()
        {
            Command = CommandBuilder(@"select id, name, contact, contactPerson, email, password, headId, description, address," +
                                     " cityId, createDate, employeeId from Ledger where (email = @email or contact=@email) and password= @password");
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Id = Convert.ToInt32(Reader["id"]);
                Name = Reader["name"].ToString();
                Contact = Reader["contact"].ToString();
                ContactPerson = Reader["contactPerson"].ToString();
                Email = Reader["email"].ToString();
                Password = Reader["password"].ToString();
                HeadId = Convert.ToInt32(Reader["headId"]);
                Description = Reader["description"].ToString();
                Address = Reader["address"].ToString();
                CityId = Convert.ToInt32(Reader["cityId"]);
              //  CreateDate = (DateTime)Reader["creatDate"];
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select L.id, L.name, L.contact, L.contactPerson, L.email, L.password, h.name  as head,
            L.description, L.address, ct.name as city, cn.name as country, l2.name as employee, L.createDate
            from Ledger as L
            left join Head as h on L.headId = h.id
            left join ledger as l2 on l.employeeId = l2.id
            left join City as ct on L.cityid = ct.id 
            left join country as cn on ct.countryId = cn.id where l.id>0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and (l.name like @search or l.contact like @search or l.contactPerson like @search or l.email like @search or l.description like @search or l.address like @search)";
                Command.Parameters.AddWithValue("@search", "%"+Search+"%");
            }
            if (HeadId > 0)
            {
                Command.CommandText += " and (h.id like @head)";
                Command.Parameters.AddWithValue("@head", "%" + HeadId + "%");
            }

            if (DateSearch)
            {
                Command.CommandText += " and l.createDate between @date1 and @Date2";
                Command.Parameters.AddWithValue("@date1", DateFrom.ToShortDateString());
                Command.Parameters.AddWithValue("@date2", DateTo.ToShortDateString());
            }

          return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Ledger( id int identity primary key ,
                                        name varchar(200) not null unique, contact varchar(200),
                                        contactPerson varchar(200) default 'NA', email varchar(200) not null unique,
                                        [password] varchar(200) not null, headId int, [description] varchar(500),
                                        [address] varchar(500), cityId int, createDate datetime default getdate(),
                                        employeeId int, foreign key (headId) references Head(id),
                                        foreign key (cityId) references City(id),
                                        foreign key (employeeId) references Ledger(id))");
            return ExecuteNQ(Command);
        }
    }
}
