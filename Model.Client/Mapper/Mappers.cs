using C = Model.Client.Data;
using G = Model.Global.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Mapper
{
    internal static class Mappers
    {
        internal static C.Employee ToClient(this G.Employee entity)
        {
            return new C.Employee(entity.Employee_Id, entity.LastName, entity.FirstName, entity.Email, entity.RegNat, entity.Address, entity.Phone);
        }

        internal static G.Employee ToGlobal(this C.Employee entity)
        {
            return new G.Employee()
            {
                Employee_Id = entity.Employee_Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                RegNat = entity.RegNat,
                Address = entity.Address,
                Phone = entity.Phone,
            };
        }
    }
}
