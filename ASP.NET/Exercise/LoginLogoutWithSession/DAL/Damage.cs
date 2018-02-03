using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Damage : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Quentity { get; set; }
        public string Remark { get; set; }
        public int EmployeeId { get; set; } 


        public  bool Insert()
        {
            Command = CommandBuilder("insert into Damage ( productId, dateTime, qty, remarks, employeeId) values( @productId, @dateTime, @qty, @remarks, @employeeId)");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@dateTime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@remarks", Remark);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Damage set productId=@productId, dateTime=@dateTime, qty=@qty, remarks=@remarks, employeeId=@employeeId where id=@id");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@dateTime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@remarks", Remark);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool Delete()
        {
            Command = CommandBuilder("delete from Damage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool SelectById()
        {
            Command = CommandBuilder("select id, productId, dateTime, qty, remarks, employeeId from Damage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                ProductId = Convert.ToInt32(Reader["productId"]);
                DateTime = (DateTime)Reader["dateTime"];
                Quentity = Convert.ToDecimal(Reader["qty"]);
                Remark = Reader["remarks"].ToString();
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select Product.name as product , Damage.qty, Damage.remarks,
                              Ledger.name as employee from Damage
                              left join Product on Damage.productId=Product.id
                              left join Ledger on Damage.employeeId=Ledger.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Damage(Id int identity primary key,productId int,
                                    dateTime datetime, qty float, remarks varchar(2000), employeeId int,
                                  foreign key (productId) references Product(id),
                                  foreign key (employeeId) references Ledger(id),)");
            return ExecuteNQ(Command);
        }
    }
}
