using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Mvc4Helper;
using Mvc4DataTransfer;
using Mvc4BusinessLayer;

namespace Mvc4Application.Controllers
{
    public class EmployeeApiController : ApiController
    {

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return (new EmployeeBL()).GetEmployees();         
        }

        public EmployeeDTO GetOneEmployeeByID(int id)
        {
            return (new EmployeeBL()).GetOneEmployeeByID(id);
        }                

    }
}
