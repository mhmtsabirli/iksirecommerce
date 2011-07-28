using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItemProductProperty : ModelBase
    {
        public Basket Basket { get; set; }
        public BasketItem BasketItem { get; set; }
        public ProductProperty ProductProperty { get; set; }

        public BasketItemProductProperty(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Basket basket, BasketItem basketItem, ProductProperty productProperty)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Basket = basket;
            this.BasketItem = basketItem;
            this.ProductProperty = productProperty;
        }
        public BasketItemProductProperty()
        {
        }
    }


}
