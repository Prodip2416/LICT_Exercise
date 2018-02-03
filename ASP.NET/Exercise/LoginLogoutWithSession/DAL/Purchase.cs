using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Purchase : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }  
        public int EmployeeId { get; set; }
        public int LedgerId { get; set; }
        public double Total { get; set; }
        public double Addition { get; set; }
        public double Deduction { get; set; }
        public string Remarks { get; set; } 


        public bool Insert()
        {
            Command = CommandBuilder(@"insert into Purchase (number, date, employeeId, ledgerId, total, addition, deduction, remarks)
                                values ( @number, @date, @employeeId, @ledgerId, @total, @addition, @deduction, @remarks)");

            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", DateTime.ToShortDateString());
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Purchase set number=@number, date=@date, employeeId=@employeeId, ledgerId=@ledgerId,
                                    total=@total, addition=@addition, deduction=@Deductiond, remarks=@remarkid=@id");



            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", DateTime);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        { 
            Command = CommandBuilder("delete from Purchase where id=@id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select id, number, date, employeeId, ledgerId, Total, addition, deduction,
                                       remarks from Purchase where id=@id");
            Command.Parameters.AddWithValue("@Id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Number = Convert.ToInt32(Reader["number"]);
                DateTime = Convert.ToDateTime(Reader["date"]);
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                LedgerId = Convert.ToInt32(Reader["ledgerId"]);
                Total = Convert.ToDouble(Reader["total"]);
                Addition = Convert.ToDouble(Reader["addition"]);
                Deduction = Convert.ToDouble(Reader["deduction"]);
                Remarks = Reader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select P.number, P.date, L.Name as Employee, P.total,
                              P.addition, P.deduction, P.remarks
                              from Purchase as P
                              left join Ledger L on P.employeeId=L.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Purchase ( id int identity primary key, number int unique not null,
                                        date datetime, employeeId int, ledgerId int, total float, addition float,
                                        deduction float, remarks varchar(2000),
                                        foreign key (employeeId) references Ledger(id),
                                        foreign key (ledgerId) references Ledger(id))");
            return ExecuteNQ(Command);
        }
    }
}
