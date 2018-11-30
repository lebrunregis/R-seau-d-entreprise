using Model.Client.Data;
using Model.Client.Mapper;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS = Model.Global.Service;

namespace Model.Client.Service
{
    public static class AuthService
    {

        public static int? Confirm(String email, string pwd)
        {

            return GS.AuthService.Confirm(email, pwd);
        }
        public static int Register(Data.Employee e)
        {

            return GS.AuthService.Register(Mappers.ToGlobal(e));
        }
        public static bool IsAdmin(int Employee_Id)
        {

            return GS.AuthService.IsAdmin(Employee_Id);
        }
    }
}
