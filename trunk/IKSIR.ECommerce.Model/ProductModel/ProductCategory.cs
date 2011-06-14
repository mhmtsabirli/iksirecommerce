using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductCategory : ModelBase
    {
        public List<ProductCategory> ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategory(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            List<ProductCategory> parentId, string title, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.ParentId = parentId;
            this.Title = title;
            this.Description = description;
        }

        public ProductCategory()
        {
        }
    }
}
