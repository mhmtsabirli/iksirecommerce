using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class Basket : ModelBase
    {
        public Address BillingAddress { get; set; }
        public EnumValue Status { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public Basket(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Address billingAddress, EnumValue status, List<BasketItem> basketItems)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BillingAddress = billingAddress;
            this.Status = Status;
            this.BasketItems = basketItems;
        }
        public Basket()
        {
        }
    }


}
