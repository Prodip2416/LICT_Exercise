using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Reports:MyBase
    {
        public DataSet CashFlow(DateTime date1,DateTime date2)
        {
            Command = CommandBuilder("select * From vwTranscation where Date between @date1 and @date2");
            Command.Parameters.AddWithValue("@date1", date1.ToShortDateString());
            Command.Parameters.AddWithValue("@date2", date2.ToShortDateString());
            return ExecuteDS(Command);
        }
    }
}
