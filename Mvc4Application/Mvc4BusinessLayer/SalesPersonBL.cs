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

    public class SalesPersonBL
    {
        private SqlDA _SqlDa;
        private OrderBL _objOrderBL;

        public SalesPersonBL(string connectionString = null)
        {
            _SqlDa = new SqlDA(connectionString);
        }

        public SalesPersonBL(ref SqlDA da)
        {
            _SqlDa = da;
        }

        //load one data row into EmployeeDTO object
        private void LoadRowIntoDto(ref SalesPersonDTO dto, DataRow dr)
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

            //sales person's properties
            dto.TerritoryName = RowFieldLoader.GetString(dr, "TerritoryName");
            dto.TerritoryGroup = RowFieldLoader.GetString(dr, "TerritoryGroup");
            dto.SalesQuota = RowFieldLoader.GetDecimal(dr, "SalesQuota");
            dto.SalesYTD = RowFieldLoader.GetDecimal(dr, "SalesYTD");
            dto.SalesLastYear = RowFieldLoader.GetDecimal(dr, "SalesLastYear");

            if (_objOrderBL == null)
                _objOrderBL = new OrderBL(ref _SqlDa);

            dto.SalesOrders = _objOrderBL.GetOrdersBySalesPersonID(dto.ID);

        }



        public List<SalesPersonDTO> GetSalesPersons()
        {

            List<SalesPersonDTO> dtos = new List<SalesPersonDTO>();

            DataTable dt = _SqlDa.GetDataTable("select * from v_SalesPersons order by BusinessEntityID", "SalesPersons");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SalesPersonDTO dto = new SalesPersonDTO();
                    LoadRowIntoDto(ref dto, dr);
                    dtos.Add(dto);
                }
            }

            return dtos;

        }


        public SalesPersonDTO GetOneSalesPersonByID(int businessEntityID)
        {

            SalesPersonDTO dto = new SalesPersonDTO();

            DataTable dt = _SqlDa.GetDataTable(string.Format("select * from v_SalesPersons where BusinessEntityID={0}",
                                                             businessEntityID.ToString()), "SalesPerson");
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                LoadRowIntoDto(ref dto, dr);
            }

            return dto;

        }








//        create view v_SalesPersons

//as

//(

//select vSales.*, tEmp.BirthDate, tEmp.Gender
//from Sales.vSalesPerson vSales
//left join HumanResources.Employee tEmp on vSales.BusinessEntityID = tEmp.BusinessEntityID

//)



    }
}
