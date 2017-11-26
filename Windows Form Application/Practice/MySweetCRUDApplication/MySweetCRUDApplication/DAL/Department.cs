using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetCRUDApplication.DAL
{
    class Department:MyBase
    {
        public DataSet Select()
        {
            return ExecuteDS("select id,Name from Department");
        }
    }
}
