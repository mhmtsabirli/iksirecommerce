using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductPrice : ModelBase
    {
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        public List<ProductShipmentPrice> ProductShipmentPrice { get; set; }

        public ProductPrice(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Product product, decimal price, decimal unitPrice, int tax, List<ProductShipmentPrice> productShipmentPrice)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Product = product;
            this.Price = price;
            this.Tax = tax;
            this.UnitPrice = unitPrice;
            this.ProductShipmentPrice = productShipmentPrice;
        }

        public ProductPrice()
        {
        }
    }
}
