using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Product : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Offers { get; set; }
        public double Discount { get; set; }
        public bool Insert()
        {
            Command = CommandBuilder(@"insert into Product ( name, description, tag, code, type, categoryId, brandId, offers, discount)
                             values ( @name, @description, @tag, @code, @type, @categoryId, @brandId, @offers, @discount)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@CategoryId", CategoryId);
            Command.Parameters.AddWithValue("@brandId", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Product set name=@name, description=@description, tag=@tag, code=@code, type=@type
                              categoryId=@categoryId, brandId=@brandId, offers=@offers, discount=@discount where id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@CategoryId", CategoryId);
            Command.Parameters.AddWithValue("@brandId", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Product where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder("select id, name, description, tag, code, type, categoryId, brandId, offers, discount from Product where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                Tag = Reader["tag"].ToString();
                Code = Reader["code"].ToString();
                Type = Reader["type"].ToString();
                CategoryId = Convert.ToInt32(Reader["categoryId"]);
                BrandId = Convert.ToInt32(Reader["brandId"]);
                Offers =Reader["offers"].ToString();
                Discount = Convert.ToDouble(Reader["discount"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select P.id, P.name, P.description, P.tag, P.code, P.type,
                                C.name as category,B.name as brand, P.offers, P.discount
                                from Product as P
                                left join Category as C on P.categoryId=C.id
                                left join Brand as B on P.brandId=B.id where p.id>0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += @" and ( P.name like @Search or p.description like @Search or p.tag like @Search or p.code like @Search or p.type like @Search
                                    or p.offers like @Search or p.discount like @Search)";
                Command.Parameters.AddWithValue("@Search", "%" + Search + "%");
            }

            if (CategoryId > 0)
            {
                Command.CommandText += " and C.id like @category";
                Command.Parameters.AddWithValue("@category", CategoryId);
            }

            if (BrandId > 0)
            {
                Command.CommandText += " and B.id like @brand";
                Command.Parameters.AddWithValue("@brand", BrandId);
            }


            return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Product ( id int identity Primary key, name varchar(200),
                                      description varchar(2000), tag varchar(200), code varchar(200) unique,
                                      type varchar(5), categoryId int not null, brandId int not null,
                                      offers varchar(2000), discount float,
                                      foreign key (categoryId) references Category(id),
                                      foreign key (brandId) references Brand(id))");
            return ExecuteNQ(Command);
        }
    }
}
