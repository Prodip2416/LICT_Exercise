using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Production : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Quentity { get; set; }
        public string ActualQuentity { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ManufuctureDate { get; set; }
        public string Number { get; set; }
        public int FormulaId { get; set; }
        public int EmployeeId { get; set; }


        public bool Insert()
        {
            Command = CommandBuilder(@"insert into Production ( productId, qty, actualQty, expireDate, manufuctureDate, number, formulaId, employeeId) 
                                        values( @productId, @qty, @actualQty, @expireDate, @manufuctureDate, @number, @formulaId, @employeeId)");

            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@actualQty", ActualQuentity);
            Command.Parameters.AddWithValue("@expireDate", ExpireDate);
            Command.Parameters.AddWithValue("@manufuctureDate", ManufuctureDate);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@formulaId", FormulaId);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Production set productId=@productId, qty=@qty, actualQty=@actualQty, expireDate=@expireDate, manufuctureDate=@manufuctureDate,
                                     number=@number, formulaId=@formulaId, employeeId=@employeeId  where id=@id");

            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@actualQty", ActualQuentity);
            Command.Parameters.AddWithValue("@expireDate", ExpireDate);
            Command.Parameters.AddWithValue("@manufuctureDate", ManufuctureDate);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@formulaId", FormulaId);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Production whid=id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select id, productId, qty, actualQty, [expireDate], manufuctureDate,
                                        number, formulaId, employeeId from Production where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                ProductId = Convert.ToInt32(Reader["productId"].ToString());
                Quentity = Reader["qty"].ToString();
                ActualQuentity = Reader["actualQty"].ToString();
                ExpireDate = Convert.ToDateTime(Reader["expireDate"]);
                ManufuctureDate = Convert.ToDateTime(Reader["manufuctureDate"]);
                Number = Reader["number"].ToString();
                FormulaId = Convert.ToInt32(Reader["formulaId"]);
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select P.Id, pp.name as product, P.Qty, P.ActualQty, P.[ExpireDate],
                                P.manufuctureDate, P.number, F.name as formula, L.name as employee 
                                from Production as P
                                left join Product as pp on P.productId=pp.id
                                left join Formula as F on P.formulaId=F.id
                                left join Ledger as L on P.employeeId=L.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Production (id int identity primary key,
                                       productId int, qty varchar(200), actualQty varchar(200),
                                       expireDate datetime, manufuctureDate datetime, number varchar(200),
                                       formulaId int ,employeeId int,
                                       foreign key (productId) references Product(id),
                                       foreign key (formulaId) references Formula(id),
                                       foreign key (employeeId) references Ledger(id),)");
            return ExecuteNQ(Command);
        }
    }
}
