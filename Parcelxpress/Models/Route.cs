using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Models
{
    public enum Cage
    {
        A, B, C, D, E, F, G, H
    }
    public class Route
    {
        public int ID { get; set; }
        public DateTime RoutDate { get; set; }
        public int DriverID { get; set; }
        public int CarID { get; set; }
        public int AreaID { get; set; }
        public Cage Cage { get; set; }

        public Driver Driver { get; set; }
        public Car Car { get; set; }
        public Area Area { get; set; }
    }
}
