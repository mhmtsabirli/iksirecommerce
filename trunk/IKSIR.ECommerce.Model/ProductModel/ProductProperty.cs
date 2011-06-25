using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductProperty : ModelBase
    {
        public Property Property { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }
        public ProductProperty(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Property property, int productid, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Property = property;
            this.ProductId = productid;
            this.Value = value;
        }
        public ProductProperty()
        {
        }
    }


}
