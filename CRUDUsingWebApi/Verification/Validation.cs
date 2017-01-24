using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDUsingWebApi.Models;
using System.Net.Mail;

namespace CRUDUsingWebApi.Verification
{
    public class Validation
    {
        IEmployeeRepository employeeRepository;

        Validation()
        {
            employeeRepository = new EmployeeRepository();
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
                    //return false;
                    throw new Exception("Email error");
                }
            }
        }

        public bool ValidateAndExecuteUpdate(Employee em)
        {
           
            if(ValidateAll(em))
            {

            }
        }

    }
}