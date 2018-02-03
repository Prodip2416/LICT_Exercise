using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL
{
    public class SalesDetails : MyBase,IDatabase
    {
        public int SalesId  { get; set; }
        public int ProductId { get; set; }
        public decimal Quentity { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }       

        public bool Insert()
        {
            Command = CommandBuilder(@"insert into SalesDetails ( salesId, productId, qty, rate, discount, vat)
                                       values(@salesId, @productId, @quentity, @rate, @discount, @vat)");

            Command.Parameters.AddWithValue("@salesId", SalesId);
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@quentity", Quentity);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update SalesDetails set qty=@quentity, rate=@rate, discount=@discount, vat=@vat where purchaseId=@purchaseId , salesId=@salesId");
         
            Command.Parameters.AddWithValue("@quentity", Quentity);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat);
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@salesId", SalesId);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from SalesDetails where purchaseId=@purchaseId , salesId=@salesId");
            Command.Parameters.AddWithValue("@SalesId", SalesId);
            Command.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder("select qty, rate, discount, vat from SalesDetails where  purchaseId=@purchaseId , salesId=@salesId");
            Command.Parameters.AddWithValue("@SalesId", SalesId);
            Command.Parameters.AddWithValue("@productId", ProductId);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Quentity = Convert.ToDecimal(Reader["qty"]);
                Rate = Convert.ToDecimal(Reader["rate"]);
                Discount = Convert.ToDecimal(Reader["discount"]);
                Vat = Convert.ToDecimal(Reader["vat"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select D.SalesId, P.Name as product, D.qty, D.rate, D.discount, D.vat 
                              from SalesDetails as D
                              left join Product as P on D.productId=P.id
                              left join Sales as s on D.salesId = s.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table SalesDetails( salesId int , productId int, qty float,
                                      rate float, discount float, vat float,
                                      foreign key(SalesId) references Sales(id),
                                      foreign key(ProductId) references Product(id),
                                      primary key(salesId, productId))");
            return ExecuteNQ(Command);
        }
    }
}
