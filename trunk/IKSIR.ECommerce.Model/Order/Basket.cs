using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class Basket : ModelBase
    {
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public EnumValue Status { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public Shipment ShippingCompany { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalRatedPrice { get; set; }

        public Basket(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Address billingAddress, Address shippingAddress, EnumValue status, List<BasketItem> basketItems, Shipment shippingCompany, decimal totalPrice, decimal totalRatedPrice)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BillingAddress = billingAddress;
            this.ShippingAddress = shippingAddress;
            this.Status = Status;
            this.BasketItems = basketItems;
            this.ShippingCompany = shippingCompany;
            this.TotalPrice = totalPrice;
            this.TotalRatedPrice = TotalRatedPrice;

        }
        public Basket()
        {
        }
    }


}
