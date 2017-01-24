using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDUsingWebApi.Models;
using CRUDUsingWebApi.Verification;

namespace CRUDUsingWebApi.Controllers
{
    //public class EmployeeController : ApiController
    //{
    //    // GET api/values
    //        public IEnumerable<string> Get()
    //        {
    //            return new string[] { "value1", "value2" };
    //        }

    //        // GET api/values/5
    //        public string Get(int id)
    //        {
    //            return "value";
    //        }

    //        // POST api/values
    //        public void Post([FromBody]string value)
    //        {
    //        }

    //        // PUT api/values/5
    //        public void Put(int id, [FromBody]string value)
    //        {
    //        }

    //        // DELETE api/values/5
    //        public void Delete(int id)
    //        {
    //        }
    //    }
    //}

    public class EmployeeController : ApiController
    {
        readonly EmployeeRepository employeeRepository = new EmployeeRepository();

        //public EmployeeController()
        //{
        //    employeeRepository = new EmployeeRepository();
        //}

        public HttpResponseMessage GetAllEmployees()
        {
            List<Employee> stuList = employeeRepository.GetAll().ToList();
            return Request.CreateResponse<List<Employee>>(HttpStatusCode.OK, stuList);
        }

        public HttpResponseMessage GetEmployee(int id)
        {
            Employee employee = employeeRepository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not found for the Given ID");
            }

            else
            {
                return Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);
            }
        }

        public HttpResponseMessage PostEmployee(Employee employee)
        {
            Validation v = new Validation();
            //if (!v.ValidateName(employee.fname))
            //{
            //    throw new Exception("First name is not valid");
            //}
            //else if (!v.ValidateName(employee.lname))
            //{
            //    throw new Exception("Last name is not valid");
            //}
            //else if (!v.ValidateEmail(employee.email))
            //{
            //    throw new Exception("Email is not valid");
            //}
            //else
            //{
            int result = v.InsertEmployee(employee);
            //employeeRepository.Add(employee);
            if (result == 1)
            {
                var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);
                string uri = Url.Link("DefaultApi", new { email = employee.email });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Student Not Added");
            }
        }

        public HttpResponseMessage PutEmployee(int id, Employee employee)
        {
            Validation v = new Validation();
            //if (!v.ValidateName(employee.fname))
            //{
            //    throw new Exception("First name is not valid");
            //}
            //else if (!v.ValidateName(employee.lname))
            //{
            //    throw new Exception("Last name is not valid");
            //}
            //else if (!v.ValidateEmail(employee.email))
            //{
            //    throw new Exception("Email is not valid");
            //}
            //else
            //{
            employee.id = id;

            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Student for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteEmployee(int id)
        {
            employeeRepository.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
