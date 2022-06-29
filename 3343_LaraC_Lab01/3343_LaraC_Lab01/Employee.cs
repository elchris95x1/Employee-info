using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3343_LaraC_Lab01
{
    public class Employee
    {
        //private field declaration
        private string _name;
        private int _idNumber;
        private string _department;
        private string _position;

        //constructor
        public Employee()
        {
            _name = "";
            _idNumber = 0;
            _department = "";
            _position = "";
        }

        //Parameterized constructor
        public Employee(string name, int idNumber, string department, string position)
        {
            _name = name;
            _idNumber = idNumber;
            _department = department;
            _position = position;
        }

        //Name Property
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        //Id Number Property
        public int IdNumber
        {
            get
            {
                return _idNumber;
            }
            set
            {
                _idNumber = value;
            }
        }

        //Department Property
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
            }
        }

        //Position Property
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }


    }
}
