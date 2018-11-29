using Model.Client.Data;
using Model.Client.Mapper;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public static class AuthService
    {

        public static int? Confirm(String email, string pwd)
        {

            return AuthService.Confirm(email, pwd);
        }
        public static int Register(Data.Employee e)
        {

            return AuthService.Register(e);
        }
        public static bool IsAdmin(int Employee_Id)
        {

            return AuthService.IsAdmin(Employee_Id);
        }
    }
}
