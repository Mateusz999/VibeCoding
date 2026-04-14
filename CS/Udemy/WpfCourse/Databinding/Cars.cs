using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCourse.Databinding
{
    class Cars
    {

        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Owner="Mike",
                    Type = CarType.Sedan,
                    Brand = BrandName.Audi
                },
                new Car()
                {
                    Owner="John",
                    Type = CarType.SUV,
                    Brand = BrandName.Hyuidai
                },
                new Car()
                {
                    Owner="Brandon",
                    Type = CarType.Hatchback,
                    Brand = BrandName.Ford
                }
            }.ToList();
        }
    }
}
