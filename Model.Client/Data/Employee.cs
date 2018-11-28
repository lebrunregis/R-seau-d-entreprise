using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Employee
    {
        private int? _employee_Id;
        private string _lastName;
        private string _firstName;
        private string _email;
        private string _passwd;
        private bool _actif;
        private string _regNat;
        private string _coordGps;
        private string _address;
        private string _phone;
        private bool? _isAdmin;

        public Employee( int? employee_Id, string lastName, string firstName, string email, string passwd, bool actif, string regNat, string coordGps, string address, string phone, bool isAdmin)
        {
            Employee_Id = employee_Id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
            Actif = actif;
            RegNat = regNat;
            CoordGps = coordGps;
            Address = address;
            Phone = phone;
            IsAdmin = isAdmin;
        }

        public Employee(string lastName, string firstName, string email, string passwd, string regNat, string address, string phone)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
            Actif = true;
            RegNat = regNat;
            CoordGps = "";
            Address = address;
            Phone = phone;
        }

        public int? Employee_Id { get => _employee_Id; set => _employee_Id = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Passwd { get => _passwd; set => _passwd = value; }
        public Boolean Actif { get => _actif; set => _actif = value; }
        public string RegNat { get => _regNat; set => _regNat = value; }
        public string CoordGps { get => _coordGps; set => _coordGps = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public bool? IsAdmin { get => _isAdmin; set => _isAdmin = value; }




        public string FullName
        {
            get { return $"{LastName} {FirstName}"; }
        }

        public string Identifier
        {
            get { return $"{LastName} {FirstName} ({Email})"; }
        }


    }
}
