using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class EmployeeService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static IEnumerable<Data.Employee> GetAllActive()
        {
            Command cmd = new Command("SP_GetAllActiveEmployees", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee());
        }
    }
}
