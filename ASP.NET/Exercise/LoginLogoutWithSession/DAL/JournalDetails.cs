using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class JournalDetails : MyBase,IDatabase
    {
        public int JournalId { get; set; }
        public int LedgerId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Remarks { get; set; } 

        public bool Insert()
        {
            Command = CommandBuilder("insert into JournalDetails (journalId, ledgerId, debit, credit, remarks) values( @journalId, @ledgerId, @debit, @credit, @remarks)");
            Command.Parameters.AddWithValue("@journalId", JournalId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder("update JournalDetails set debit=@debit, credit=@credit, remarks=@remarks where journalId=@journalId");
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            Command.Parameters.AddWithValue("@journalId", JournalId);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from JournalDetails where journalId=@journalId");
            Command.Parameters.AddWithValue("@journalId", JournalId);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        { 
            Command = CommandBuilder("select journalId, ledgerId, debit, credit, remarks from JournalDetails where journalId=@journalId");
            Command.Parameters.AddWithValue("@journalId", JournalId);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                JournalId = Convert.ToInt32(Reader["journalId"]);
                LedgerId = Convert.ToInt32(Reader["ledgerId"]);
                Debit = Convert.ToDecimal(Reader["debit"]);
                Credit = Convert.ToDecimal(Reader["redit"]);
                Remarks = Reader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS("select journalId, ledgerId, debit, credit, remarks from JournalDetails");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table JournalDetails(journalId int not null,
                                       ledgerId int not null,Debit float,Credit float,Remarks varchar(2000),
                                       foreign key (journalId) references Journal(Id),
                                       foreign key (ledgerId) references Ledger(Id),
                                       Primary key (journalId,ledgerId))");
            return ExecuteNQ(Command);
        }
    }
}
