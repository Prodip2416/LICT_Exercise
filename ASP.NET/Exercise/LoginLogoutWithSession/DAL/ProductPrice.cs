using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class ProductPrice : MyBase,IDatabase
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }   

        public bool Insert()
        {
            Command = CommandBuilder("insert into ProductPrice ( productId, unitId, price) values( @productId, @unitId, @price)");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@unitId", UnitId);
            Command.Parameters.AddWithValue("@price", Price);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder("update ProductPrice set price=@price where productId=@productId, unitId=@unitId");
            Command.Parameters.AddWithValue("@price", Price);
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@unitId", UnitId);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from ProductPrice where productId=@productId, unitId=@unitId");
            Command.Parameters.AddWithValue("@productId",ProductId);
            Command.Parameters.AddWithValue("@unitId", UnitId);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select productId, unitId, price from 
                                 ProductPrice where productId=@productId, unitId=@unitId");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@unitId", UnitId);
            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Price = Convert.ToDouble(Reader["price"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select p.name,u.name as unit,pp.price
                                from ProductPrice as pp
                                left join Product as p on pp.productId=p.id
                                left join Unit as u on pp.unitId=u.id where p.id > 0");

         

            if (ProductId > 0)
            {
                Command.CommandText += " and p.id like @product";
                Command.Parameters.AddWithValue("@product", ProductId);
            }
            if (UnitId > 0)
            {
                Command.CommandText += " and u.id like @unit";
                Command.Parameters.AddWithValue("@unit", UnitId);
            }
            return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table ProductPrice ( productId int not null,
                                        unitId int not null,Price float,
                                        foreign key (productId) references Product(Id),
                                        foreign key (unitId) references Unit(id),
                                        primary key (productId, unitId))");
            return ExecuteNQ(Command);
        }
    }
}
