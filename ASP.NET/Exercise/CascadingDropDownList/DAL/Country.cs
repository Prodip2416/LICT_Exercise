using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Country:MyBase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }

  
        public DataSet SelectCountry()
        {
            Command = CommandBuilder("select CountryId, CountryName from tblCountries ");

            if (ContinentId > 0)
            {
                Command.CommandText += "where ContinentId =@continentId";
                Command.Parameters.AddWithValue("@continentId", ContinentId);
            }
            return ExecuteDS(Command);
        }
   
    }
}
