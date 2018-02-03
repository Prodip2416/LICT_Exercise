using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Journal : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public int VoucherId { get; set; }  
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int EmpoloyeeId { get; set; }
        public string ReMarks { get; set; } 


        public  bool Insert()
        {
            Command = CommandBuilder("insert into Journal ( ledgerId, voucherId, number, date, debit, credit, employeeId, remarks) values ( @ledgerId, @voucherId, @number, @date, @debit, @credit, @employeeId, @remarks) select @@identity");
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@voucherId", VoucherId);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@employeeId", EmpoloyeeId);
            Command.Parameters.AddWithValue("@remarks", ReMarks);
            return ExecuteScaler(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Journal set ledgerId=@ledgerId, voucherId=@voucherId, number=@number,
                   date=@date, debit=@debit, credit=@credit, employeeId=@employeeId, remarks=@remarks where id=@id");
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@voucherId", VoucherId);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@employeeId", EmpoloyeeId);
            Command.Parameters.AddWithValue("@remarks", ReMarks);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Journal where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select id, ledgerId, voucherId, number, date, debit, credit, employeeId, remarks 
                                       from Journal where id=@Id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                LedgerId = Convert.ToInt32(Reader["ledgerId"]);
                VoucherId = Convert.ToInt32(Reader["voucherId"]);
                Number = Reader["number"].ToString();
                Date = Convert.ToDateTime(Reader["date"]);
                Debit = Convert.ToDecimal(Reader["debit"]);
                Credit = Convert.ToDecimal(Reader["credit"]);
                EmpoloyeeId = Convert.ToInt32(Reader["employeeId"]);
                ReMarks = Reader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select Journal.ledgerId as ledgerId, voucher.name as voucher,
                                Journal.number, Journal.debit, Journal.credit,
                                Journal.remarks, Ledger.name as employee from Journal
                                left join Voucher on Journal.VoucherId=Voucher.id 
                                left join Ledger on Journal.employeeId=Ledger.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Journal(Id int identity primary key,
                                        ledgerId int,VoucherId int not null,
                                        Number varchar(20) unique not null,[Date] datetime,
                                        Debit float,Credit float,employeeId int,Remarks varchar(2000),
                                        foreign key (ledgerId) references Ledger(Id),
                                        foreign key (VoucherId) references Voucher(Id),
                                        foreign key (employeeId) references Ledger(Id))");
            return ExecuteNQ(Command);
        }
    }
}
