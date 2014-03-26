using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc4DataTransfer;
using Mvc4DataAccess;
using Mvc4Helper;
using System.Data;

namespace Mvc4BusinessLayer
{
    public class EmployeeBL
    {

        private SqlDA _SqlDa;

        public EmployeeBL(string connectionString = null)
        {
            _SqlDa = new SqlDA(connectionString);  
        }

        public EmployeeBL(ref SqlDA da)
        {
            _SqlDa = da;
        }
        
        //load one data row into EmployeeDTO object
        private void LoadRowIntoDto(ref EmployeeDTO dto, DataRow dr)
        {
            dto.ID = RowFieldLoader.GetInt(dr, "BusinessEntityID");
            dto.FirstName = RowFieldLoader.GetString(dr, "FirstName");
            dto.MiddleName = RowFieldLoader.GetString(dr, "MiddleName");
            dto.LastName = RowFieldLoader.GetString(dr, "LastName");
            dto.BirthDate = RowFieldLoader.GetDateTime(dr, "BirthDate");
            dto.Gender = RowFieldLoader.GetString(dr, "Gender");
            if (dto.Gender == "M")
                dto.Gender = "Male";
            else
                dto.Gender = "Female";
            dto.JobTitle = RowFieldLoader.GetString(dr, "JobTitle");
            dto.PhoneNumber = RowFieldLoader.GetString(dr, "PhoneNumber");
            dto.PhoneNumberType = RowFieldLoader.GetString(dr, "PhoneNumberType");
            dto.EmailAddress = RowFieldLoader.GetString(dr, "EmailAddress");
            dto.EmailPromotion = RowFieldLoader.GetBoolean(dr, "EmailPromotion");
            dto.AddressLine1 = RowFieldLoader.GetString(dr, "AddressLine1");
            dto.AddressLine2 = RowFieldLoader.GetString(dr, "AddressLine2");
            dto.City = RowFieldLoader.GetString(dr, "City");
            dto.StateProvinceName = RowFieldLoader.GetString(dr, "StateProvinceName");
            dto.PostalCode = RowFieldLoader.GetString(dr, "PostalCode");
            dto.CountryRegionName = RowFieldLoader.GetString(dr, "CountryRegionName");
        }



        public List<EmployeeDTO> GetEmployees()
        {

            List<EmployeeDTO> dtos = new List<EmployeeDTO>();

            DataTable dt = _SqlDa.GetDataTable("select * from v_Employees order by BusinessEntityID", "Employees");
            if (dt != null && dt.Rows.Count > 0)
            {

               foreach (DataRow dr in dt.Rows)
               {
                   EmployeeDTO dto = new EmployeeDTO();
                   LoadRowIntoDto(ref dto, dr);
                   dtos.Add(dto);
               }

            }

            return dtos;

        }


        public EmployeeDTO GetOneEmployeeByID(int businessEntityID)
        {

            EmployeeDTO dto = new EmployeeDTO();

            DataTable dt = _SqlDa.GetDataTable(string.Format("select * from v_Employees where BusinessEntityID={0}", 
                                                             businessEntityID.ToString()), "Employee");
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                LoadRowIntoDto(ref dto, dr);
            }

            return dto;

        }




        // Make sure have create this following View first
      
         //create view v_Employees
         //   as

         //   (


         //   select vEmp.*, tEmp.BirthDate, tEmp.Gender
         //   from HumanResources.vEmployee vEmp
         //   left join HumanResources.Employee tEmp on vEmp.BusinessEntityID = tEmp.BusinessEntityID


         //   )




    }
}
