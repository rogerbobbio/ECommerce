using System;
using System.Linq;
using ECommerce.Models;

namespace ECommerce.Classes
{
    public class DBHelper
    {
        public static Response SaveChanges(ECommerceContext db)
        {
            try
            {
                db.SaveChanges();
                return new Response
                {
                    Succeeded = true,
                };
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    Succeeded = false,
                };
                if (ex.InnerException != null && 
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "There are a record with the same value.";
                }
                else if (ex.InnerException != null && 
                         ex.InnerException.InnerException != null &&
                         ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "The record can't be delete because it has related records.";
                }
                else
                {
                    response.Message = ex.Message;
                }

                return response;
            }
        }

        public static int GetOrderState(string descrption, ECommerceContext db)
        {
            var state = db.OrderStates.FirstOrDefault(s => s.Description == descrption);
            if (state == null)
            {
                state = new OrderState
                {
                    Description = descrption,
                };
                db.OrderStates.Add(state);
                db.SaveChanges();
            }
            return state.OrderStateId;
        }
    }
}