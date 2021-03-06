﻿using System;
using System.Collections;
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

        public static List<City> GetCities(int departmentId)
        {
            var city = db.Cities.Where(c => c.DepartmentId == departmentId).ToList();
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
            projectState.Add(new ProjectState { ProjectStateId = 0, Name = "[Seleciona un Estado...]" });
            return projectState.OrderBy(d => d.Name).ToList();
        }

        public static List<PensionSystem> GetPensionSystems()
        {
            var pensionSystem = db.PensionSystems.ToList();
            pensionSystem.Add(new PensionSystem { PensionSystemId = 0, Name = "[Seleciona un Sistema...]" });
            return pensionSystem.OrderBy(d => d.Name).ToList();
        }        

        public static List<Project> GetProjects(int companyId)
        {
            var project = db.Projects.Where(c => c.CompanyId == companyId).ToList();
            project.Add(new Project { ProjectId = 0, Name = "[Seleciona un Proyecto...]" });
            return project.OrderBy(d => d.Name).ToList();
        }

        public static List<UserRol> GetUserRols()
        {
            var userRol = db.UserRols.ToList();
            userRol.Add(new UserRol { UserRolId = 0, Name = "[Seleciona un Rol...]" });
            return userRol.OrderBy(d => d.Name).ToList();
        }

        public static List<UserRol> GetUserRols(int companyId)
        {
            var userRol = db.UserRols.Where(c => c.CompanyId == companyId).ToList();
            userRol.Add(new UserRol { UserRolId = 0, Name = "[Seleciona un Rol...]" });
            return userRol.OrderBy(d => d.Name).ToList();
        }

        public static List<ProductCategory> GetProductCategories()
        {
            var productCategory = db.ProductCategories.ToList();
            productCategory.Add(new ProductCategory { ProductCategoryId = 0, Description = "[Seleciona una Categoria...]" });
            return productCategory.OrderBy(d => d.Description).ToList();
        }

        public static List<ProductCategory> GetProductCategories(int companyId)
        {
            var productCategory = db.ProductCategories.Where(c => c.CompanyId == companyId).ToList();
            productCategory.Add(new ProductCategory { ProductCategoryId = 0, Description = "[Seleciona una Categoria...]" });
            return productCategory.OrderBy(d => d.Description).ToList();
        }

        public static List<Tax> GetTaxes()
        {
            var tax = db.Taxes.ToList();
            tax.Add(new Tax { TaxId = 0, Description = "[Seleciona un Impuesto...]" });
            return tax.OrderBy(d => d.Description).ToList();
        }

        public static List<Tax> GetTaxes(int companyId)
        {
            var tax = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            tax.Add(new Tax { TaxId = 0, Description = "[Seleciona un Impuesto...]" });
            return tax.OrderBy(d => d.Description).ToList();
        }


        public static List<Customer> GetCustomers()
        {
            var customer = db.Customers.ToList();
            customer.Add(new Customer { CustomerId = 0, FirstName = "[Seleciona un Cliente...]" });
            return customer.OrderBy(d => d.UserName).ThenBy(c => c.LastName).ToList();
        }

        public static List<Customer> GetCustomers(int companyId)
        {
            var qry = (from cu in db.Customers
                       join cc in db.CompanyCustomers on cu.CustomerId equals cc.CustomerId
                       join co in db.Companies on cc.CompanyId equals co.CompanyId
                      where co.CompanyId == companyId
                       select new { cu }).ToList();

            var customers = new List<Customer>();
            foreach (var item in qry)
            {
                customers.Add(item.cu);
            }

            customers.Add(new Customer { CustomerId = 0, FirstName = "[Seleciona un Cliente...]" });
            return customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }


        public static List<Supplier> GetSuppliers()
        {
            var supplier = db.Suppliers.ToList();
            supplier.Add(new Supplier { SupplierId = 0, FirstName = "[Seleciona un Proveedor...]" });
            return supplier.OrderBy(d => d.UserName).ThenBy(c => c.LastName).ToList();
        }

        public static List<Supplier> GetSuppliers(int companyId)
        {
            var qry = (from cu in db.Suppliers
                       join cc in db.CompanySuppliers on cu.SupplierId equals cc.SupplierId
                       join co in db.Companies on cc.CompanyId equals co.CompanyId
                where co.CompanyId == companyId
                select new { cu }).ToList();

            var suppliers = new List<Supplier>();
            foreach (var item in qry)
            {
                suppliers.Add(item.cu);
            }

            suppliers.Add(new Supplier { SupplierId = 0, FirstName = "[Seleciona un Proveedor...]" });
            return suppliers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }


        public static List<Product> GetProducts()
        {
            var product = db.Products.ToList();
            product.Add(new Product { ProductId = 0, Description = "[Seleciona un Producto...]" });
            return product.OrderBy(d => d.Description).ToList();
        }

        public static List<Product> GetProducts(bool popup)
        {
            var product = db.Products.ToList();            
            return product.OrderBy(d => d.Description).ToList();
        }

        public static List<Product> GetProducts(int companyId)
        {
            var product = db.Products.Where(c => c.CompanyId == companyId).ToList();
            product.Add(new Product { ProductId = 0, Description = "[Seleciona un Producto...]" });
            return product.OrderBy(c => c.Description).ToList();
        }

        public static List<Product> GetProducts(int companyId, bool popup)
        {
            var products = db.Products.Where(p => p.CompanyId == companyId).ToList();
            return products.OrderBy(p => p.Description).ToList();
        }


        public void Dispose()
        {
            db.Dispose();
        }        
    }
}