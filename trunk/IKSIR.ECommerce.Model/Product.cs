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
        public int ProductCategoryId { get; set; }

        public Product CreateProduct(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate,string title, string description, string productcode, int minstock, DateTime alertdate, int productcategoryid) 
        {
            Product p = new Product();
            p.Title = title;
            p.Description = description;
            p.ProductCode = productcode;
            p.MinStock = minstock;
            p.AlertDate = alertdate;
            p.ProductCategoryId = productcategoryid;
            p.CreateBase(id, createUserId, createdate, edituser, editdate);
            
            return p;
        }
    }
}
