using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
