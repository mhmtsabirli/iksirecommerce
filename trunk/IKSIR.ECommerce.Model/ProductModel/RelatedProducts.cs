using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class RelatedProducts : ModelBase
    {
        public Product Product { get; set; }
        public Product RelatedProduct { get; set; }

        public RelatedProducts(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Product product, Product relatedProduct)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Product = product;
            this.RelatedProduct = relatedProduct;

        }

        public RelatedProducts()
        {
        }
    }
}
