using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class Product : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int MinStock { get; set; }
        public string Video { get; set; }
        public bool OnSale { get; set; }
        public DateTime AlertDate { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductPrice ProductPrice { get; set; }
        public List<Product> RelatedProduct { get; set; }

        public Product(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title,
            string description, string video, string productCode,bool onSale , int minStock, DateTime alertdate, List<Product> relatedProduct, ProductCategory productCategory, ProductPrice productPrice) 
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Video = video;
            this.Title = title;
            this.Description = description;
            this.ProductCode = productCode;
            this.OnSale = onSale;
            this.MinStock = minStock;
            this.AlertDate = alertdate;
            this.ProductCategory = productCategory;
            this.ProductPrice = productPrice;
            this.RelatedProduct = relatedProduct;
        }
        public Product()
        {
            // TODO: Complete member initialization
        }
    }
       
}
