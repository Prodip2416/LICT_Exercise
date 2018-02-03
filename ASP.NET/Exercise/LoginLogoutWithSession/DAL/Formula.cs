using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    sealed class Formula : MyBase, IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public double Quentity { get; set; }

        public bool Insert()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("insert into Formula (Name,productId,Qty) values(@Name,@ProductId,@Qty) select @@identity ");
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@ProductId", ProductId);
            Command.Parameters.AddWithValue("@Qty", Quentity);
            return ExecuteScaler(Command);
        }

        public bool Update()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("update Formula set Name=@Name,productId=@ProductId,Qty=@Qty where Id=@Id");
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@ProductId", ProductId);
            Command.Parameters.AddWithValue("@Qty", Quentity);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("delete from Formula where Id=@Id");
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("select id, name, productId, qty from Formula where Id=@Id");
            Command.Parameters.AddWithValue("@Id", Id);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                ProductId = Convert.ToInt32(Reader["productId"]);
                Quentity = Convert.ToDouble(Reader["qty"].ToString());
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            return ExecuteDS("select f.id, f.name, p.name as product , f.qty from formula f left join product p on f.productId = p.id");
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Formula(Id int identity primary key,
                                       Name varchar(200),productId int,Qty float,
                                       foreign key (productId) references Product(Id))");
            return ExecuteNQ(Command);
        }
    }
}
