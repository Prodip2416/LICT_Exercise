using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PurchaseDetails : MyBase,IDatabase
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public double Quentity { get; set; }
        public double Rate { get; set; }
        public double Discount { get; set; }
        public double Vat { get; set; }       

        public bool Insert()
        {
            Command = CommandBuilder(@"insert into PurchaseDetails ( purchaseId, productId, qty, rate, discount, vat)
                                       values ( @purchaseId, @productId, @quentity, @rate, @discount, @vat)");

            Command.Parameters.AddWithValue("@purchaseId", PurchaseId);
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@quentity", Quentity);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update PurchaseDetails set qty=@quentity, rate=@rate, discodiscount, vat=@vat where purchaseId=@PurchaseId");

            Command.Parameters.AddWithValue("@purchaseId", PurchaseId);
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@quentity", Quentity);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from PurchaseDetails where purchaseId=@PurchaseId");
            Command.Parameters.AddWithValue("@purchaseId", PurchaseId);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder("select purchaseId, productId , qty, rate, discount, vat from PurchaseDetails where purchaseId=@purchaseId");
            Command.Parameters.AddWithValue("@PurchaseId", PurchaseId);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Quentity = Convert.ToDouble(Reader["qty"]);
                Rate = Convert.ToDouble(Reader["rate"]);
                Discount = Convert.ToDouble(Reader["discount"]);
                Vat = Convert.ToDouble(Reader["vat"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
          return  ExecuteDS(@"select C.Id , P.Name as Product, D.qty as Quentity, D.rate,
                                D.discount, D.vat from PurchaseDetails as D
                                left join Product p on D.productId=P.id
                                left join Purchase C on D.purchaseId=C.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table PurchaseDetails ( purchaseId int not null,
                                        productId int not null, Qty float,Rate float,
                                        Discount float, Vat float,
                                        foreign key (purchaseId) references Purchase(id),
                                        foreign key (productId) references product(id),
                                        primary key (purchaseId, productId))");
            return ExecuteNQ(Command);
        }
    }
}
