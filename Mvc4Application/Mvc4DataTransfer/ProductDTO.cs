using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
    }
}
