using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CRUDUsingWebApi;

using CRUDUsingWebApi.Models;

using Rhino.Mocks;
using CRUDUsingWebApi.Verification;

namespace EmployeeDetailsTest
    {
        [TestClass]
        public class EmployeeControllerTest
        {
            [TestMethod]
            public void PostMethod_withEmptyFirstName_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "";
                obj1.lname = "AV";
                obj1.email = "chandanav@gmail.com";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.InsertEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("First Name cannot be empty \n", e.Message);
                }
            }

            [TestMethod]
            public void PostMethod_withEmptyLastName_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "";
                obj1.email = "chandanav@gmail.com";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.InsertEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Last Name Cannot be empty\n", e.Message);
                }
            }

            [TestMethod]
            public void PostMethod_withEmptyEmail_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "AV";
                obj1.email = "";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.InsertEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email id cannot be empty \n", e.Message);
                }
            }


            [TestMethod]
            public void PostMethod_withInvalidEmail_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "AV";
                obj1.email = "chandanavgmail.com";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.InsertEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email error", e.Message);
                }
            }


            [TestMethod]

            public void PutMethod_withEmptyEmail_ThrowsException()

            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "AV";
                obj1.email = "";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.UpdateEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email id cannot be empty \n", e.Message);
                }
            }



            [TestMethod]
            public void PutMethod_withEmptyLastName_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "";
                obj1.email = "chandan@gmail.com";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.UpdateEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Last Name Cannot be empty\n", e.Message);
                }
            }



            [TestMethod]
            public void PutMethod_withEmptyFirstName_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "";
                obj1.lname = "AV";
                obj1.email = "chandan@gmail.com";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.UpdateEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("First Name cannot be empty \n", e.Message);
                }
            }

            [TestMethod]
            public void PutMethod_withInavlidEmail_ThrowsException()
            {
                Employee obj1 = new Employee();
                obj1.fname = "Chandan";
                obj1.lname = "AV";
                obj1.email = "chandancom";
                obj1.status = "Activated";
                var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);
                Validation mockEmpCrtl = new Validation(mockEmployeeRepository);
                try
                {
                    mockEmpCrtl.UpdateEmployee(obj1);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email error", e.Message);
                }
            }
        }
}
