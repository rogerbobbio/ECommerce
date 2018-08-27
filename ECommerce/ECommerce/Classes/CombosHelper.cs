using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;

namespace ECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();

        public static List<Department> GetDepartments()
        {
            var department = db.Departments.ToList();
            department.Add(new Department { DepartmentId = 0, Name = "[Select a department...]" });
            return department.OrderBy(d => d.Name).ToList();
        }

        public static List<City> GetCities()
        {
            var city = db.Cities.ToList();
            city.Add(new City { CityId = 0, Name = "[Select a city...]" });
            return city.OrderBy(d => d.Name).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}