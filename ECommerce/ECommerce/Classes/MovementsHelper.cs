using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Configuration;
using ECommerce.Models;

namespace ECommerce.Classes
{    
    public class MovementsHelper: IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public static Response NewOrder(NewOrderView newOrder, string userName)
        {
            using (var transacction = db.Database.BeginTransaction())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.UserName == userName);
                    int companyId;
                    var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
                    if (adminUser == userName)
                        companyId = newOrder.CompanyId;
                    else
                        companyId = user.CompanyId;

                    var order = new Order
                    {
                        CompanyId = companyId,
                        CustomerId = newOrder.CustomerId,
                        ProjectId = newOrder.ProjectId,
                        Date = newOrder.Date,
                        Remarks = newOrder.Remarks,
                        OrderStateId = DBHelper.GetOrderState("Created", db),
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();

                    var details = db.OrderDetailTmps.Where(odt => odt.UserName == userName).ToList();
                    foreach (var orderDetailTmp in details)
                    {
                        var orderDetail = new OrderDetail
                        {
                            Description = orderDetailTmp.Description,
                            OrderId = order.OrderId,
                            Price = orderDetailTmp.Price,
                            ProductId = orderDetailTmp.ProductId,
                            Quantity = orderDetailTmp.Quantity,
                            TaxRate = orderDetailTmp.TaxRate,
                        };

                        db.OrderDetails.Add(orderDetail);
                        db.OrderDetailTmps.Remove(orderDetailTmp);
                    }
                    db.SaveChanges();
                    transacction.Commit();
                    return new Response {Succeeded = true};
                }
                catch (Exception ex)
                {
                    transacction.Rollback();
                    return new Response { Message = ex.Message, Succeeded = false};                    
                }
            }
        }

        public static Response NewBudget(NewBudgetView newBudget, string userName)
        {
            using (var transacction = db.Database.BeginTransaction())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.UserName == userName);
                    int companyId;
                    var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
                    if (adminUser == userName)
                        companyId = newBudget.CompanyId;
                    else
                        companyId = user.CompanyId;

                    var budget = new Budget
                    {
                        CompanyId = companyId,
                        CustomerId = newBudget.CustomerId,
                        ProjectId = newBudget.ProjectId,
                        Date = newBudget.Date,
                        Remarks = newBudget.Remarks,
                        TotalButget = newBudget.TotalButget,
                    };
                    db.Budgets.Add(budget);
                    db.SaveChanges();

                    var details = db.BudgetDetailTmps.Where(odt => odt.UserName == userName).ToList();
                    foreach (var budgetDetailTmp in details)
                    {
                        var budgetDetail = new BudgetDetail
                        {
                            Description = budgetDetailTmp.Description,
                            BudgetId = budget.BudgetId,
                            Category = budgetDetailTmp.Category,
                            CategoryCode = budgetDetailTmp.CategoryCode,
                            Subcategory = budgetDetailTmp.Subcategory,
                            SubcategoryCode = budgetDetailTmp.SubcategoryCode,
                            Unity = budgetDetailTmp.Unity,
                            UnitPrice = budgetDetailTmp.UnitPrice,
                            PartialPrice = budgetDetailTmp.PartialPrice,
                            Remarks = budgetDetailTmp.Remarks,
                        };

                        db.BudgetDetails.Add(budgetDetail);
                        db.BudgetDetailTmps.Remove(budgetDetailTmp);
                    }
                    db.SaveChanges();

                    var budgetEdit = db.Budgets.FirstOrDefault(odt => odt.BudgetId == budget.BudgetId);
                    budgetEdit.TotalButget = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId).Sum(a => a.PartialPrice);
                    db.Entry(budgetEdit).State = EntityState.Modified;
                    
                    db.SaveChanges();
                    transacction.Commit();
                    return new Response { Succeeded = true };
                }
                catch (Exception ex)
                {
                    transacction.Rollback();
                    return new Response {Message = ex.Message, Succeeded = false};
                }
            }
        }
    }
}