using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoobDAL
{
    public class Person:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; } 
        public string Email { get; set; }
        public int Gender { get; set; }
        public double Balance { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public string Note { get; set; }
        public int CnId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Active { get; set; }

        public bool Insert()
        {
            Command = CommandBuilder(@"INSERT INTO `person_info`(`name`, `contactNo`, `email`, `gender`, `balance`, `address`, `userType`, `note`, `cn_id`, `entryDate`, `active`) VALUES 
                          (@name, @contactNo, @email, @gender, @balance, @address, @userType, @note, @cnId, @date, @active)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contactNo", ContactNo);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@gender", Gender);
            Command.Parameters.AddWithValue("@balance", Balance);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@userType", UserType);
            Command.Parameters.AddWithValue("@note", Note);
            Command.Parameters.AddWithValue("@cnId", CnId);
            Command.Parameters.AddWithValue("@date", EntryDate);
            Command.Parameters.AddWithValue("@active", Active);

            return ExecuteNq(Command);
        }
        // Update Data to person table
        public bool Update()
        {
            Command = CommandBuilder(@"UPDATE `person_info` SET `name`=@name,`contactNo`=@contactNo,
           `email`=@email,`gender`=@gender,`balance`=@balance,`address`=@address,`userType`=@userType,`note`=@note,
                         `cn_id`=@cnId,`entryDate`=@date,`active`=@active WHERE id=@id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contactNo", ContactNo);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@gender", Gender);
            Command.Parameters.AddWithValue("@balance", Balance);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@userType", UserType);
            Command.Parameters.AddWithValue("@note", Note);
            Command.Parameters.AddWithValue("@cnId", CnId);
            Command.Parameters.AddWithValue("@date", EntryDate);
            Command.Parameters.AddWithValue("@active", Active);

            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNq(Command);
        }
        // Delete form person
        public bool Delete()
        {
            Command = CommandBuilder("delete from person_info where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNq(Command);
        }
        // Read data from database
        public bool SelectById()
        {
            Command = CommandBuilder(@"SELECT `id`, `name`, `contactNo`, `email`, `gender`, `balance`, `address`, `userType`, " +
                                     "`note`, `cn_id`, `entryDate`, `active` FROM `person_info` WHERE id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Id = Convert.ToInt16(Reader["id"]);
                Name = Reader["name"].ToString();
                ContactNo = Reader["contactNo"].ToString();
                Email = Reader["email"].ToString();
                Gender = Convert.ToInt32(Reader["gender"]);
                Balance = Convert.ToDouble(Reader["balance"]);
                Address = Reader["address"].ToString();
                UserType = Reader["userType"].ToString();
                Note = Reader["note"].ToString();
                CnId = Convert.ToInt32(Reader["cn_id"]);
                EntryDate = Convert.ToDateTime(Reader["entryDate"]);
                Active = Convert.ToBoolean(Reader["active"]);     
                return true;
            }
            return false;
        }
       
        public DataSet Select()
        {
            Command = CommandBuilder(@"SELECT `id`, `name`, `contactNo`, `email`, `gender`, `balance`, `address`,
                        `userType`, `note`, `cn_id`, `entryDate`, `active` FROM `person_info`");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            Thread.Sleep(5000);
            return ExecuteDs(Command);
        }

        //public async Task<DataTable> ExecuteDsMultiThreading()
        //{
        //    var dt = new DataTable();
        //    var cn = @"datasource=localhost;database=crm;username=root;password=;";
        //    var cmd = @"SELECT `id`, `name`, `contactNo`, `email`, `gender`, `balance`, `address`,
        //                `userType`, `note`, `cn_id`, `entryDate`, `active` FROM `person_info`";
        //    var da = new SqlDataAdapter(cmd, cn);
        //    await Task.Run(() => { da.Fill(dt); });
        //    return dt;

        //}
    }
}
