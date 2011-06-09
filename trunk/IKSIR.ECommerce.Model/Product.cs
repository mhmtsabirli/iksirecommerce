using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Product : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int MinStock { get; set; }
        public DateTime AlertDate { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title,
            string description, string productCode, int minStock, DateTime alertdate, ProductCategory productCategory) 
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Title = title;
            this.Description = description;
            this.ProductCode = productCode;
            this.MinStock = minStock;
            this.AlertDate = alertdate;
            this.ProductCategory = productCategory;
            
            
            
        }
    }
}
