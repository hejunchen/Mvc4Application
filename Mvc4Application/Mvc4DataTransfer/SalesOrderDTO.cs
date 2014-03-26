using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class SalesOrderDTO
    {
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<SalesOrderDetailDTO> OrderDetails { get; set; }
    }
}
