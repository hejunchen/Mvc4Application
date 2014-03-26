using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc4BusinessLayer;
using Mvc4DataTransfer;
using Mvc4Helper;
using System.Configuration;

namespace Mvc4Application.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeesObjectTest()
        {

            List<EmployeeDTO> Employees = (new EmployeeBL(ConfigurationManager.ConnectionStrings["EmployeeDB"].ToString())).GetEmployees();

            if (Employees != null && Employees.Count > 0)
            {
                Assert.IsTrue(Employees != null);
            }
            else
            {
                Assert.Fail("Employees object cannot be created.");
            }


        }
    }
}
