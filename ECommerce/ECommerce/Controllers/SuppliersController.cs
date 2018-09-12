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
    public class SuppliersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var suppliers = new List<Supplier>();

            //verifica el usuario logeado y filtra por su compania
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var qry = (from cu in db.Suppliers
                join cc in db.CompanySuppliers on cu.SupplierId equals cc.SupplierId
                join co in db.Companies on cc.CompanyId equals co.CompanyId
                where co.CompanyId == user.CompanyId
                select new { cu }).ToList();

            foreach (var item in qry)
            {
                suppliers.Add(item.cu);
            }

            
            suppliers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
            return View(suppliers.ToPagedList((int)page, 5));
        }

        public void ExportToExcel()
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var suppplierList = (from cu in db.Suppliers
                join cc in db.CompanySuppliers on cu.SupplierId equals cc.SupplierId
                join co in db.Companies on cc.CompanyId equals co.CompanyId
                where co.CompanyId == user.CompanyId
                select new { cu }).ToList();

            var pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Lista de Proveedores";
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
            foreach (var item in suppplierList)
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
            var supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
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
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                using (var transacction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Suppliers.Add(supplier);
                        var response = DBHelper.SaveChanges(db);
                        if (!response.Succeeded)
                        {
                            ModelState.AddModelError(string.Empty, response.Message);
                            transacction.Rollback();
                            ViewBag.CityId = new SelectList(CombosHelper.GetCities(supplier.DepartmentId), "CityId", "Name", supplier.CityId);
                            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", supplier.DepartmentId);
                            //ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", customer.CompanyId);
                            return View(supplier);
                        }

                        //UsersHelper.CreateUserASP(customer.UserName, "Customer");
                        var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                        var companySupplier = new CompanySupplier
                        {
                            CompanyId = user.CompanyId,
                            SupplierId = supplier.SupplierId,
                        };
                        db.CompanySuppliers.Add(companySupplier);
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

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(supplier.DepartmentId), "CityId", "Name", supplier.CityId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", supplier.DepartmentId);
            return View(supplier);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(supplier.DepartmentId), "CityId", "Name", supplier.CityId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", supplier.DepartmentId);
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    //TODO: Validate when the customer email change
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(supplier.DepartmentId), "CityId", "Name", supplier.CityId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", supplier.DepartmentId);
            return View(supplier);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplier = db.Suppliers.Find(id);            
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var companySupplier = db.CompanySuppliers.FirstOrDefault(cc => cc.CompanyId == user.CompanyId && cc.SupplierId == supplier.SupplierId);

            using (var transacction = db.Database.BeginTransaction())
            {
                db.CompanySuppliers.Remove(companySupplier);
                db.Suppliers.Remove(supplier);
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    //UsersHelper.DeleteUser(customer.UserName, "Customer");
                    transacction.Commit();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
                transacction.Rollback();
                return View(supplier);
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
