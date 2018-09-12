using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;
using OfficeOpenXml;
using PagedList;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User")]
    public class CustomersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var customers = new List<Customer>();

            //verifica el usuario logeado y filtra por su compania
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var qry = (from cu in db.Customers
                join cc in db.CompanyCustomers on cu.CustomerId equals cc.CustomerId
                join co in db.Companies on cc.CompanyId equals co.CompanyId
                where co.CompanyId == user.CompanyId
                select new {cu}).ToList();

            foreach (var item in qry)
            {
                customers.Add(item.cu);
            }

            customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
            return View(customers.ToPagedList((int)page, 5));
        }

        public void ExportToExcel()
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var customerList = (from cu in db.Customers
                join cc in db.CompanyCustomers on cu.CustomerId equals cc.CustomerId
                join co in db.Companies on cc.CompanyId equals co.CompanyId
                where co.CompanyId == user.CompanyId
                select new { cu }).ToList();

            var pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Lista de Clientes";
            ws.Cells["A1"].Style.Font.Size = 20;
            ws.Cells["A1"].Style.Font.Bold = true;


            ws.Cells["A6"].Value = "User Name";
            ws.Cells["A6"].Style.Font.Bold = true;

            ws.Cells["B6"].Value = "Full Name";
            ws.Cells["B6"].Style.Font.Bold = true;

            ws.Cells["C6"].Value = "City";
            ws.Cells["C6"].Style.Font.Bold = true;

            ws.Cells["D6"].Value = "Department";
            ws.Cells["D6"].Style.Font.Bold = true;

            ws.Cells["E6"].Value = "Phone";
            ws.Cells["E6"].Style.Font.Bold = true;            

            var rowStart = 7;
            foreach (var item in customerList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.cu.UserName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.cu.FullName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.cu.City.Name;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.cu.Department.Name;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.cu.Phone;                
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(0), "CityId", "Name");
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name");
            
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");
            
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var transacction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Customers.Add(customer);
                        var response = DBHelper.SaveChanges(db);
                        if (!response.Succeeded)
                        {
                            ModelState.AddModelError(string.Empty, response.Message);
                            transacction.Rollback();
                            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartmentId), "CityId","Name", customer.CityId);
                            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", customer.DepartmentId);
                            //ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", customer.CompanyId);
                            return View(customer);
                        }

                        //UsersHelper.CreateUserASP(customer.UserName, "Customer");
                        var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                        var companyCustomer = new CompanyCustomer
                        {
                            CompanyId = user.CompanyId,
                            CustomerId = customer.CustomerId,
                        };
                        db.CompanyCustomers.Add(companyCustomer);
                        db.SaveChanges();
                        transacction.Commit();
                        return RedirectToAction("Index");                        
                    }
                    catch (Exception ex)
                    {
                        transacction.Rollback();
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartmentId), "CityId", "Name", customer.CityId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", customer.DepartmentId);
            //ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", customer.CompanyId);
            return View(customer);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartmentId), "CityId", "Name", customer.CityId);            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", customer.DepartmentId);
            
            return View(customer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {                
                db.Entry(customer).State = EntityState.Modified;
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    //TODO: Validate when the customer email change
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartmentId), "CityId", "Name", customer.CityId);            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", customer.DepartmentId);
            //ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", customer.CompanyId);
            return View(customer);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = db.Customers.Find(id);
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var companyCustomer = db.CompanyCustomers.FirstOrDefault(cc => cc.CompanyId == user.CompanyId && cc.CustomerId == customer.CustomerId);

            using (var transacction = db.Database.BeginTransaction())
            {
                db.CompanyCustomers.Remove(companyCustomer);
                db.Customers.Remove(customer);
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    //UsersHelper.DeleteUser(customer.UserName, "Customer");
                    transacction.Commit();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
                transacction.Rollback();
                return View(customer);
            }
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
