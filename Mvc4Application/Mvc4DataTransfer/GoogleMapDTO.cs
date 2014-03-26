using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class GoogleMapDTO
    {
        public string MapControllerID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Address { get; set; }
        public int Zoom { get; set; }


    }
}
