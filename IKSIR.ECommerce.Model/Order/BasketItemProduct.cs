using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;
namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItemProduct : ModelBase
    {
        public Basket Basket { get; set; }
        public BasketItem BasketItem { get; set; }
        public Product Product { get; set; }

        public BasketItemProduct(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Basket basket, BasketItem basketItem, Product product)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Basket = basket;
            this.BasketItem = basketItem;
            this.Product = product;
        }
        public BasketItemProduct()
        {
        }
    }


}
