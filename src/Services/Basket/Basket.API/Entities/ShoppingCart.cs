using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public ShoppingCart(string userName)
        {
            this.UserName = userName;
            this.Items = new List<ShoppingCartItem>();
        }

        public string UserName { get; set; }
        
        public List<ShoppingCartItem> Items { get; set; }

        public decimal TotalPrice 
        {
            get
            {
                decimal totalPrice = 0;
                if(Items != null)
                {
                    foreach (var item in Items)
                    {
                        totalPrice += item.Price * item.Quantity;
                    }
                }
                return totalPrice;
            }
        }
    }
}
