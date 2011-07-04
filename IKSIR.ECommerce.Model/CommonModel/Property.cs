using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Property : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }

        public Property(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title, string description, string value, int productId)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Title = title;
            this.Description = description;
            this.Value = value;
            this.ProductId = productId;
        }
        public Property()
        {
        }
    }
}
