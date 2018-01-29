using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
      public class City : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public DataSet SelectCity()
        {
            Command = CommandBuilder("select CityId, CityName from tblCities ");

            if (CountryId > 0)
            {
                Command.CommandText += "where CountryId =@countryId";
                Command.Parameters.AddWithValue("@countryId", CountryId);
            }
            return ExecuteDS(Command);
        }

    }
}
