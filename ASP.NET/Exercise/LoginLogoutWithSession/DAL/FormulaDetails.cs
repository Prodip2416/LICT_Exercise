using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class FormulaDetails : MyBase, IDatabase
    {
        public int FormulaId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public string Remarks { get; set; }


        public bool Insert()
        {
            Command = CommandBuilder(@"insert into FormulaDetails (formulaid, productid,qty,remarks) values(@formulaid, @productid,@qty,@remarks)");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update  FormulaDetails set formulaid=@formulaid, productid=@productid qty=@qty,remarks=@remarks where formulaid=@formulaid and productid=@productid");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder(@"delete from FormulaDetails where formulaid=@formulaid and productid=@productid,");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            return ExecuteNQ(Command);
        }


        public bool SelectById()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder(@"select formulaid, productid, qty, remarks 
                                        from FormulaDetails where formulaid=@formulaid and productid=@productid");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Qty = Convert.ToDouble(Reader["qty"]);
                Remarks = Reader["remarks"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = CommandBuilder(@"select  fd.formulaid, f.name formula, fd.productid, p.name product,
               fd.qty, fd.remarks from FormulaDetails fd 
               left join formula f on fd.formulaId = f.id 
               left join product p on fd.productId = p.id where fd.formulaId > 0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and fd.remarks like @search";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (ProductId > 0)
            {
                Command.CommandText += " and  p.id like @product";
                Command.Parameters.AddWithValue("@product", ProductId);

            }
            if (FormulaId > 0)
            {
                Command.CommandText += " and f.id  like @formula";
                Command.Parameters.AddWithValue("@formula", FormulaId);

            }

            return ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"Create table FormulaDetails
                                            (
                                            FormulaId int,
                                            ProductId int ,
                                            Qty float,
                                            Remarks varchar(2000),
                                            foreign key (ProductId) references Product(Id),
                                            foreign key (FormulaId) references Formula(Id),
                                            primary key(ProductId,FormulaId)
                                            )");
            return ExecuteNQ(Command);
        }

    }
}
