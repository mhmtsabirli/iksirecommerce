using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItem : ModelBase
    {
        public Basket Basket { get; set; }
        public Product Product { get; set; }
        public Address ShippingAddress { get; set; }        
        public ProductPrice ProductPrice { get; set; }
        public int Count { get; set; }
        public EnumValue Status { get; set; }
        public decimal BasketItemPrice
        {
            get { return this.ProductPrice!=null ? this.ProductPrice.Price * Count : 0; }
        }
        public BasketItem(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Basket basket, Product product, Address shippingAddress, ProductPrice productPrice, int count, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Basket = basket;
            this.Product = product;
            this.ShippingAddress = shippingAddress;
            this.ProductPrice = productPrice;
            this.Count = count;
            this.Status = status;
        }
        public BasketItem()
        {
        }
    }


}
