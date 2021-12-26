using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Models
{
    public class Route
    {
        public int ID { get; set; }
        public DateTime RouteDate { get; set; }
        public int DriverID { get; set; }
        public int CarID { get; set; }
        public int AreaID { get; set; }

        public Driver Driver { get; set; }
        public Car Car { get; set; }
        public Area Area { get; set; }
    }
}
