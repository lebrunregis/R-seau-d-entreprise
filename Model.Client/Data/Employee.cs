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
        private string _CoordGPS;
        private string _Address;
        private string _Phone;

        public int Employee_Id
        {
            get
            {
                return _Employee_Id;
            }

            private set
            {
                _Employee_Id = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                _LastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                _FirstName = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Passwd
        {
            get
            {
                return _Passwd;
            }

            set
            {
                _Passwd = value;
            }
        }
        public Boolean Actif
        {
            get
            {
                return _Actif;
            }

            set
            {
                _Actif = value;
            }
        }

        public string RegNat
        {
            get
            {
                return _RegNat;
            }

            set
            {
                _RegNat = value;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
            }
        }
        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public string FullName
        {
            get { return $"{LastName} {FirstName}"; }
        }

        public Employee(string lastName, string firstName, string email, string passwd, string regNat, string address, string phone)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
            RegNat = regNat;
            Address = address;
            Phone = phone;
        }

        internal Employee(int id, string lastName, string firstName, string email, string passwd, string regNat, string address, string phone) : this(lastName, firstName, email, passwd, regNat, address, phone)
        {
            Employee_Id = id;
        }
    }
}
