using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductCategory : ModelBase
    {
        public ProductCategory ParentCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategory(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            ProductCategory parentCategory, string title, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.ParentCategory = parentCategory;
            this.Title = title;
            this.Description = description;
        }

        public ProductCategory()
        {

        }
    }
}
