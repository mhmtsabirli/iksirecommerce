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
        public BasketItemAddres BillingAddress { get; set; }
        public EnumValue Status { get; set; }

        public Basket(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, BasketItemAddres billingAddress,  EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BillingAddress = billingAddress;
            this.Status = Status;
        }
        public Basket()
        {
        }
    }


}
