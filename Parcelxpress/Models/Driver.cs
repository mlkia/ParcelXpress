using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
