using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class SalesOrderDetailDTO
    {
        public int SalesOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderQty {get;set;}
        public decimal Total { get; set; }
    }
}
