using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUDUsingWebApi.Models;
using CRUDUsingWebApi.Verification;
using CRUDUsingWebApi.Controllers;
namespace TestForValidation
{
    [TestClass]
    public class UnitTest1
    {
            [TestMethod]
            public void TestForCreatingWithEmptyFirstNameThrowsException()
            {
                Employee Em = new Employee();
                Em.fname = "";
                Em.lname = "Hegde";
                Em.email = "dhanya.chidambtieto.com";
                Em.status = "activated";
                var em = new Validation();
                //Employee em = new Employee();
                try
                {
                em.ValidateEmail(Em.email);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email error", e.Message, "Error");
                }
            }
            [TestMethod]
            public void TestForCreatingWithEmptyLastNameThrowsException()
            {
            Employee Em = new Employee();
            Em.fname = "Dhanya";
            Em.lname = "";
            Em.email = "dhanya.chidambar@tieto.com";
            Em.status = "activated";
            var em = new Validation();
            try
                {
                em.ValidateName(Em.lname);
            }
                catch (Exception e)
                {
                    Assert.AreEqual("Last name is not valid", e.Message, "Error");
                }
            }
            [TestMethod]
            public void TestForCreatingWithEmptyEmailThrowsException()
            {
            Employee Em = new Employee();
            Em.fname = "";
            Em.lname = "Hegde";
            Em.email = "";
            Em.status = "activated";
            var em = new Validation();
                try
                {
                    em.ValidateEmail(Em.email);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email is not valid", e.Message, "Error");
                }
            }

            [TestMethod]
            public void TestForCreatingWithInvalidNonEmptyEmailThrowsException()
            {
            Employee Em = new Employee();
            Em.fname = "";
            Em.lname = "Hegde";
            Em.email = "jdcj";
            Em.status = "activated";
            var em = new Validation();
            try
                {
                    em.ValidateEmail(Em.email);
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Email error", e.Message, "Error");
                }
            }

            [TestMethod]
            public void TestForCorrectDetails()
            {
            Employee Em = new Employee();
            Em.fname = "Dhanya";
            Em.lname = "Hegde";
            Em.email = "Dhanya.hegde@gmail.com";
            Em.status = "activated";
            var em = new Validation();
                bool status=em.ValidateAll(Em);
                    Assert.AreEqual(true, status, "Error");
            }
           
        }
    }

