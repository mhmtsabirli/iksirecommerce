using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductCategories : ModelBase
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategories(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            int parentId, string title, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.ParentId = parentId;
            this.Title = title;
            this.Description = description;

        }
    }
}
