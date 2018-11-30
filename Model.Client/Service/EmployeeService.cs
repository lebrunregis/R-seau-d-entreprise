using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;

namespace Model.Client.Service
{
    public static class EmployeeService
    {

        public static IEnumerable<Employee> GetAllActive()
        {
            List<Employee> ClientEmployees = new List<Employee>();
            IEnumerable<GD.Employee> GlobalEmployees = GS.EmployeeService.GetAllActive();
            foreach (GD.Employee employee in GlobalEmployees)
            {
                ClientEmployees.Add(Mappers.ToClient(employee));
            }
            return ClientEmployees;
        }

        public static Employee Get(int Id)
        {
            return Mappers.ToClient(GS.EmployeeService.Get(Id));
        }

        public static bool Update(Employee e)
        {
            return GS.EmployeeService.Update(Mappers.ToGlobal(e));
        }

        public static bool UpdateEmail(Employee e)
        {
            return GS.EmployeeService.UpdateEmail(Mappers.ToGlobal(e));
        }

        public static bool UpdatePassword(Employee e, string OldPass)
        {
            return GS.EmployeeService.UpdatePassword(Mappers.ToGlobal(e), OldPass);
        }

        public static bool Delete(Employee e)
        {
            return GS.EmployeeService.Delete(Mappers.ToGlobal(e));
        }

        public static Employee GetForAdmin(int Id)
        {
            return Mappers.ToClient(GS.EmployeeService.GetForAdmin(Id));
        }

        public static IEnumerable<Employee> GetAllActiveForAdmin()
        {
            List<Employee> ClientEmployees = new List<Employee>();
            IEnumerable<GD.Employee> GlobalEmployees = GS.EmployeeService.GetAllActiveForAdmin();
            foreach (GD.Employee employee in GlobalEmployees)
            {
                ClientEmployees.Add(Mappers.ToClient(employee));
            }
            return ClientEmployees;
        }

        public static bool UpdateForAdmin(Employee e)
        {

            return GS.EmployeeService.UpdateForAdmin(Mappers.ToGlobal(e));
        }

        public static IEnumerable<EmployeeStatusHistory> GetStatusHistory(int Employee_Id)
        {
            List<EmployeeStatusHistory> CESH = new List<EmployeeStatusHistory>();
            IEnumerable<GD.EmployeeStatusHistory> GESH = GS.EmployeeService.GetEmployeeStatusHistory(Employee_Id);
            foreach (GD.EmployeeStatusHistory employeeStatusHistory in GESH)
            {
                CESH.Add(Mappers.ToClient(employeeStatusHistory));
            }
            return CESH;
        }
        public static IEnumerable<ProjectManagerHistory> GetProjectManagerHistory(int Employee_Id)
        {
            List<ProjectManagerHistory> CPMH = new List<ProjectManagerHistory>();
            IEnumerable<GD.ProjectManagerHistory> GPMHs = GS.EmployeeService.GetProjectManagerHistory(Employee_Id);
            foreach (GD.ProjectManagerHistory GPMH in GPMHs)
            {
                CPMH.Add(Mappers.ToClient(GPMH));
            }
            return CPMH;
        }

    }
}
