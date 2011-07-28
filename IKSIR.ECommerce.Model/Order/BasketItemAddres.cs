using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItemAddres : ModelBase
    {     
        public Basket Basket { get; set; }
        public BasketItem BasketItem { get; set; }
        public Address Address { get; set; }

        public BasketItemAddres(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Basket basket, BasketItem basketItem, Address address)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Basket = basket;
            this.BasketItem = basketItem;
            this.Address = address;
        }
        public BasketItemAddres()
        {
        }
    }


}
