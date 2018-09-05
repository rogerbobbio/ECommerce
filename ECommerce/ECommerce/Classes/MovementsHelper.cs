using System;
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
    }
}