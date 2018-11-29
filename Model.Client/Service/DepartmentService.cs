using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public class DepartmentService
    {

        public static int? Create(Department d, int AdminId)
        {

            return GS.DepartmentService.Create(Mappers.ToGlobal(d), AdminId);
        }

        public static bool Edit(int User, Department d)
        {

            return GS.DepartmentService.Edit(User, Mappers.ToGlobal(d));
        }

        public static int? Delete(int User, int depId)
        {

            return GS.DepartmentService.Delete(User, depId);
        }

        public static Department GetDepartmentById(int Id)
        {

            return Mappers.ToClient(GS.DepartmentService.GetDepartmentById(Id));
        }

        public static IEnumerable<Department> GetAllActive()
        {
            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetAllActive();
            foreach(GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static IEnumerable<Department> GetEmployeeActiveDepartments(int id)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Department> GetAll()
        {

            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetAll();
            foreach (GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static IEnumerable<Department> GetEmployeeDepartments(int Employee_Id)
        {

            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetEmployeeDepartments(Employee_Id);
            foreach (GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static int AddEmployeeDepartment(int Employee_Id, int Department_Id,int User)
        {

            return GS.DepartmentService.AddEmployeeDepartment(Employee_Id, Department_Id,User);
        }

        public static int RemoveEmployeeDepartment(int Employee_Id, int Department_Id,int User)
        {
            return GS.DepartmentService.RemoveEmployeeDepartment(Employee_Id, Department_Id,User);
        }

        public static IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory(int Employee_Id)
        {
            List<EmployeeDepartmentHistory> ClientDepartments = new List<EmployeeDepartmentHistory>();
            IEnumerable<GD.EmployeeDepartmentHistory> GlobalDepartments = GS.DepartmentService.GetEmployeeDepartmentHistory(Employee_Id);
            foreach (GD.EmployeeDepartmentHistory department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static IEnumerable<Department> GetHeadOfDepartmentActiveDepartments(int Employee_Id)
        {
            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetHeadOfDepartmentActiveDepartments(Employee_Id);
            foreach (GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static bool ChangeHeadOfDepartment(int DepId, int EmpId, int User)
        {
            return GS.DepartmentService.ChangeHeadOfDepartment( DepId, EmpId,User);
        }

        public static int? GetHeadOfDepartmentId(int DepartmentId)
        {
            return GS.DepartmentService.GetHeadOfDepartmentId(DepartmentId);
        }

        public static IEnumerable<Employee> GetEmployeesForDepartment(int Department_Id)
        {
            List<Employee> ClientEmployees = new List<Employee>();
            IEnumerable<GD.Employee> GlobalEmployees = GS.DepartmentService.GetEmployeesForDepartment( Department_Id);
            foreach (GD.Employee Employee in GlobalEmployees)
            {
                ClientEmployees.Add(Mappers.ToClient(Employee));
            }
            return ClientEmployees;
        }
    }
}
