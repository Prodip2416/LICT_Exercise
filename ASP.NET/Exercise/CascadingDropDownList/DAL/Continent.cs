using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class Continent : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DataSet SelectContinent()
        {
            Command = CommandBuilder("select ContinentId, ContinentName from tblContinents");
            return ExecuteDS(Command);
        }
    }
}