using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mapper
{
    internal static class Mappers
    {
        internal static Employee ToEmployee(this IDataRecord dr)
        {
            return new Employee() {
                Employee_Id = (int)dr["Employee_Id"],
                LastName = (string)dr["LastName"],
                FirstName = (string)dr["FirstName"],
                Email = (string)dr["Email"],
                RegNat = (string)dr["RegNat"],
                Address = (string)dr["Address"],
                Phone = (string)dr["Phone"]
            };
        }
    }
}
