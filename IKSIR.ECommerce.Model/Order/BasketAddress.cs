using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketAddress : ModelBase
    {     
        public int BasketId { get; set; }
        public Address Address { get; set; }

        public BasketAddress(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int basketId, Address address)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BasketId = basketId;
            this.Address = address;
        }
        public BasketAddress()
        {
        }
    }


}
