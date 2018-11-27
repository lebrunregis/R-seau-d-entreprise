using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Employee
    {
        private int _Employee_Id;
        private string _LastName;
        private string _FirstName;
        private string _Email;
        private string _Passwd;
        private Boolean _Actif;
        private string _RegNat;
        private string _Address;
        private string _Phone;

        public int Employee_Id { get => _Employee_Id; set => _Employee_Id = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Passwd { get => _Passwd; set => _Passwd = value; }
        public bool Actif { get => _Actif; set => _Actif = value; }
        public string RegNat { get => _RegNat; set => _RegNat = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Phone { get => _Phone; set => _Phone = value; }

        public string FullName
        {
            get { return $"{LastName} {FirstName}"; }
        }

        public string Identifier
        {
            get { return $"{LastName} {FirstName} ({Email})"; }
        }

        public Employee(int employee_Id, string lastName, string firstName, string email, string passwd, bool actif, string regNat, string address, string phone)
        {
            Employee_Id = employee_Id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
            Actif = actif;
            RegNat = regNat;
            Address = address;
            Phone = phone;
        }
    }
}
