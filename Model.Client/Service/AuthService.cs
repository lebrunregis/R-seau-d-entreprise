using Model.Client.Mapper;
using System;
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
