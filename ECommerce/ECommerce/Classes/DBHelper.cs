using System.Linq;
using ECommerce.Models;

namespace ECommerce.Classes
{
    public class DBHelper
    {
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