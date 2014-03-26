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
    public class OrderBL
    {
        private SqlDA _SqlDa;

        public OrderBL(string connectionString = null)
        {
            _SqlDa = new SqlDA(connectionString);
        }

        public OrderBL(ref SqlDA da)
        {
            _SqlDa = da;
        }

        private void LoadRowToDto(ref SalesOrderDTO dto, DataRow dr, int id, bool loadDetails = false)
        {
            dto.SalesOrderID = RowFieldLoader.GetInt(dr, "SalesOrderID");
            dto.RevisionNumber = RowFieldLoader.GetInt(dr, "RevisionNumber");
            dto.OrderDate = RowFieldLoader.GetDateTime(dr, "OrderDate");
            dto.DueDate = RowFieldLoader.GetDateTime(dr, "DueDate");
            dto.ShipDate = RowFieldLoader.GetDateTime(dr, "ShipDate");
            dto.SubTotal = RowFieldLoader.GetDecimal(dr, "SubTotal");
            dto.TaxAmt = RowFieldLoader.GetDecimal(dr, "TaxAmt");
            dto.Freight = RowFieldLoader.GetDecimal(dr, "Freight");
            dto.TotalDue = RowFieldLoader.GetDecimal(dr, "TotalDue");
            dto.Comment = RowFieldLoader.GetString(dr, "Comment");
            dto.ModifiedDate = RowFieldLoader.GetDateTime(dr, "ModifiedDate");
            
            if (loadDetails) dto.OrderDetails = GetOrderDetailsBySalesOrderID(id);
        }

        public List<SalesOrderDTO> GetOrdersBySalesPersonID(int id)
        {
            List<SalesOrderDTO> dtos = new List<SalesOrderDTO>();

            DataTable dt = _SqlDa.GetDataTable("select * from Sales.SalesOrderHeader where SalesPersonID = " + id.ToString(), "SalesOrders");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SalesOrderDTO dto = new SalesOrderDTO();
                    LoadRowToDto(ref dto, dr, id);
                    dtos.Add(dto);
                }
            }
            
            return dtos;

        }

        public SalesOrderDTO GetOneOrderByOrderID(int id)
        {
            SalesOrderDTO dto = new SalesOrderDTO();

            DataTable dt = _SqlDa.GetDataTable("select * from Sales.SalesOrderHeader where SalesOrderID = " + id.ToString(), "SalesOrder");

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                LoadRowToDto(ref dto, dr, id, true);
            }

            return dto;
        }


        public List<SalesOrderDetailDTO> GetOrderDetailsBySalesOrderID(int id)
        {
            List<SalesOrderDetailDTO> dtos = new List<SalesOrderDetailDTO>();

            string query = "select  od.SalesOrderDetailID, od.ProductID, p.ProductNumber, p.Name as 'ProductName', od.UnitPrice, od.OrderQty, od.UnitPrice * od.OrderQty as 'Total' " +
                           "from Sales.SalesOrderDetail od " +
                           "left join Production.Product p on od.ProductID = p.ProductID " +
                           "where od.SalesOrderID = " + id.ToString() + " " +
                           "order by od.SalesOrderDetailID, od.ProductID";

            DataTable dt = _SqlDa.GetDataTable(query, "SalesOrderDetails");

            foreach (DataRow dr in dt.Rows)
            {
                SalesOrderDetailDTO dto = new SalesOrderDetailDTO();
                dto.SalesOrderDetailID = RowFieldLoader.GetInt(dr, "SalesOrderDetailID");
                dto.ProductID = RowFieldLoader.GetInt(dr, "ProductID");
                dto.ProductNumber = RowFieldLoader.GetString(dr, "ProductNumber");
                dto.ProductName = RowFieldLoader.GetString(dr, "ProductName");
                dto.UnitPrice = RowFieldLoader.GetDecimal(dr, "UnitPrice");
                dto.OrderQty = RowFieldLoader.GetInt(dr, "OrderQty");
                dto.Total = RowFieldLoader.GetDecimal(dr, "Total");
                dtos.Add(dto);
            }

            return dtos;

        }

    }
}
