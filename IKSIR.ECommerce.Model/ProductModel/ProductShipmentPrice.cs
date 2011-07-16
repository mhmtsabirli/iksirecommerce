using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductShipmentPrice : ModelBase
    {
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public Shipment Shipment { get; set; }

        public ProductShipmentPrice(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Product product, decimal price, Shipment shipment)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Product = product;
            this.Price = price;
            this.Shipment = shipment;
        }

        public ProductShipmentPrice()
        {
        }
    }
}
