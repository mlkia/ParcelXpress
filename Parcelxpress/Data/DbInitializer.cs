using Parcelxpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LoadContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.Drivers.Any())
            {
                return;  
            }

            var drivers = new Driver[]
            {
            new Driver{FirstName="Malik",LastName="Alhanouti"},
            new Driver{FirstName="Lars",LastName="Johansson"},
            new Driver{FirstName="Björn",LastName="Sandqvist"},
            new Driver{FirstName="Jonas",LastName="Landgren"},

            };
            foreach (Driver s in drivers)
            {
                context.Drivers.Add(s);
            }
            context.SaveChanges();

            var cars = new Car[]
            {
            new Car{Model="Nisan", RegNumber="PHS724"},
            new Car{Model="Volkswagen Caddy", RegNumber="DNB450"},
            new Car{Model="Iveco", RegNumber="SWF174"},
            new Car{Model="Toyota", RegNumber="XDW449"},

            };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();

            var areas = new Area[]
            {
            new Area{Name="Frölunda", PostNumber=42147 },
            new Area{Name="Göteborg", PostNumber=41108 },
            new Area{Name="Sävedalen", PostNumber=43367 },
            new Area{Name="Angered", PostNumber=42465 },
            };
            foreach (Area c in areas)
            {
                context.Areas.Add(c);
            }
            context.SaveChanges();

            var routes = new Route[]
            {
            new Route{RouteDate=DateTime.Parse("2021-12-29"), DriverID=1, CarID=1, AreaID=1, },
            new Route{RouteDate=DateTime.Parse("2021-12-12"), DriverID=3, CarID=3, AreaID=3, },
            new Route{RouteDate=DateTime.Parse("2021-01-30"), DriverID=2, CarID=2, AreaID=2, },
            new Route{RouteDate=DateTime.Parse("2021-04-08"), DriverID=4, CarID=4, AreaID=4, },

            };
            foreach (Route e in routes)
            {
                context.Routes.Add(e);
            }
            context.SaveChanges();
        }
    }
}
