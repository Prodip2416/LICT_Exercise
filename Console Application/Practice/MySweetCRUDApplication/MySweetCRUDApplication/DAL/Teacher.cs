﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetCRUDApplication.DAL
{
    class Teacher:MyBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Dept { get; set; }



        public bool Insert()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("insert into Teacher (Name,Email,Dept) values (@Name,@Email,@Dept)");
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Dept", Dept);

            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("update Teacher set Name=@Name,Email=@Email,Dept=@Dept where id=@Id");
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Dept", Dept);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }

        public bool Delete()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("delete from Teacher where id=@Id");
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
            Command = CommandBuilder("select id,Name,Email,Dept from Teacher where id=@Id");
            Command.Parameters.AddWithValue("@Id", Id);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Name = Reader["Name"].ToString();
                Email = Reader["Email"].ToString();
                Dept = Convert.ToInt32(Reader["Dept"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            return ExecuteDS("select Teacher.id,Teacher.Name,Teacher.Email,Department.Name as Department from Teacher left join Department on Teacher.Dept=Department.id");
        }
    }
}
