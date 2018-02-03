using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class ProductImage : MyBase,IDatabase
    {
       
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }    


        public bool Insert()
        {
            Command = CommandBuilder("insert into ProductImage ( productId, title, image, fileName) values (@productId, @title, @image, @fileName)");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@title", Title);
            Command.Parameters.AddWithValue("@image", Image);
            Command.Parameters.AddWithValue("@fileName", FileName);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder("update ProductImage set productId=@productId, title=@title, image=@image, fileName=@fileName where id=@id");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@title", Title);
            Command.Parameters.AddWithValue("@image", Image);
            Command.Parameters.AddWithValue("@fileName", FileName);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("delete from ProductImage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            Command = CommandBuilder("select  productId, title, image, fileName from ProductImage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Title = Reader["title"].ToString();
                Image = (byte[]) Reader["image"];
                FileName = Reader["fileName"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select pi.id, pi.title, pi.datetime, pi.image,
                             p.name as product from ProductImage as pi
                             left join Product as p on pi.productId=p.id where pi.id>0");

            if (!string.IsNullOrEmpty(Title))
            {
                Command.CommandText += " and pi.title like @title";
                Command.Parameters.AddWithValue("@title", "%" + Title + "%");
            }

            if (ProductId > 0)
            {
                Command.CommandText += " and p.id like @product";
                Command.Parameters.AddWithValue("@product", ProductId);
            }

            if (DateSearch)
            {
                Command.CommandText += " and pi.datetime between @date1 and @Date2";
                Command.Parameters.AddWithValue("@date1", DateFrom.ToShortDateString());
                Command.Parameters.AddWithValue("@date2", DateTo.ToShortDateString());
            }

            return  ExecuteDS(Command);
        }
        public  bool Table()
        {    
            Command = CommandBuilder(@"create table Country ( id int identity primary key, title varchar(200) not null,
                                       image image , fileName varchar(20) , foregin key (productId) references Product(id)");
            return ExecuteNQ(Command);
        }
    }
}
