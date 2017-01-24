using System;
using System.Collections.Generic;
using CRUDUsingWebApi.Models;
using System.Net.Mail;
namespace CRUDUsingWebApi.Verification
{
    public class InvalidException : System.Exception
    {
        public InvalidException(string s) : base(s)
        {

        }
    }
    public class Validation
    {
        private readonly IEmployeeRepository _emp;

        public Validation()
        {
            _emp = new EmployeeRepository();
        }

        public Validation(IEmployeeRepository employee)
        {

            if (employee != null)

                _emp = employee;

        }
        public bool ValidateAll(Employee em)
        {
            if (ValidateName(em.fname) && ValidateName(em.lname) && ValidateEmail(em.email))
                return true;
            else return false;
        }
        public bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            else return true;
        }

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            else
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("Email error");
                   
                }
            }
        }

        public IEnumerable<Employee> GetAll()

            {

                return _emp.GetAll();

            }



            public Employee Get(int EmployeeID)

            {

                return _emp.Get(EmployeeID);

            }



            public int InsertEmployee(Employee newEmployee)

            {
            bool status=false;
                if (ValidateAll(newEmployee))
                {
                    status = _emp.Add(newEmployee);
                }
                if (status == true)

                    return 1;

                else

                    return 0;
            }
            public int UpdateEmployee(Employee updateEmployee)
            {

            if (ValidateAll(updateEmployee))
            {
                bool status=_emp.Update(updateEmployee);
                if (status == true)
                    return 1;
                else return 0;
            }
            else
                return 0;

            }
     }
}
