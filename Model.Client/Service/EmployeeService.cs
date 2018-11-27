using Model.Client.Data;
using Model.Client.Mapper;
using G = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public static class EmployeeService
    {

        public static IEnumerable<Employee> GetAllActive()
        {

            return 
        }
        public static Employee Get(int Id)
        {

            return 
        }
        public static bool Update(Employee e)
        {

            return 
        }
        public static bool UpdateEmail(Employee e)
        {

            return 
        }
        public static bool UpdatePassword(Employee e, string OldPass)
        {
  
            return 
        }
        public static bool Delete(Employee e)
        {

            return 
        }
        public static Employee GetForAdmin(int Id)
        {

            return 
        }
        public static IEnumerable<Employee> GetAllActiveForAdmin()
        {

            return 
        }
        public static bool UpdateForAdmin (Employee e)
        {

            return 
        }
        public static IEnumerable<EmployeeStatusHistory> GetEmployeeStatusHistory(int Employee_Id)
        {

            return 
        }
        public static IEnumerable<EmployeeProjectManagerHistory> GetEmployeeProjectManagerHistory(int Employee_Id)
        {

            return
        }

    }
}
