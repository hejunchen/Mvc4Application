using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Mvc4Helper
{
    public static class Config
    {

        //public const string MVCVideoPath = @"D:\MVC Tutorials\";

        //the connection string item value is defined in web application web.config file
        public static readonly string SqlConnectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ToString();


    }
}
