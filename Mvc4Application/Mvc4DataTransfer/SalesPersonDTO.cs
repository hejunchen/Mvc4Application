using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class SalesPersonDTO : EmployeeDTO
    {
        public string TerritoryName { get; set; }
        public string TerritoryGroup { get; set; }
        public decimal SalesQuota { get; set; }
        public decimal SalesYTD { get; set; }
        public decimal SalesLastYear { get; set; }
        public List<SalesOrderDTO> SalesOrders { get; set; }
    }
}
