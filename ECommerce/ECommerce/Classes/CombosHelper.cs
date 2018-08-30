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

        public static List<Company> GetCompanies()
        {
            var company = db.Companies.ToList();
            company.Add(new Company { CompanyId = 0, Name = "[Select a company...]" });
            return company.OrderBy(d => d.Name).ToList();
        }

        public static List<ProjectState> GetProjectStates()
        {
            var projectState = db.ProjectStates.ToList();
            projectState.Add(new ProjectState { ProjectStateId = 0, Name = "[Select a Project State...]" });
            return projectState.OrderBy(d => d.Name).ToList();
        }

        public static List<PensionSystem> GetPensionSystems()
        {
            var pensionSystem = db.PensionSystems.ToList();
            pensionSystem.Add(new PensionSystem { PensionSystemId = 0, Name = "[Select a Pension System...]" });
            return pensionSystem.OrderBy(d => d.Name).ToList();
        }

        public static List<Project> GetProjects()
        {
            var project = db.Projects.ToList();
            project.Add(new Project { ProjectId = 0, Name = "[Select a Project...]" });
            return project.OrderBy(d => d.Name).ToList();
        }

        public static List<Project> GetProjects(int companyId)
        {
            var project = db.Projects.Where(c => c.CompanyId == companyId).ToList();
            project.Add(new Project { ProjectId = 0, Name = "[Select a Project...]" });
            return project.OrderBy(d => d.Name).ToList();
        }

        public static List<UserRol> GetUserRols()
        {
            var userRol = db.UserRols.ToList();
            userRol.Add(new UserRol { UserRolId = 0, Name = "[Select a User Rol...]" });
            return userRol.OrderBy(d => d.Name).ToList();
        }

        public static List<UserRol> GetUserRols(int companyId)
        {
            var userRol = db.UserRols.Where(c => c.CompanyId == companyId).ToList();
            userRol.Add(new UserRol { UserRolId = 0, Name = "[Select a User Rol...]" });
            return userRol.OrderBy(d => d.Name).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}