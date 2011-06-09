using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductProperties : ModelBase
    {
        public Property Property { get; set; }
        public int ProductId { get; set; }

        public ProductProperties(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Property property, int productid)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Property = property;
            this.ProductId = productid;

            
        }
    }
}
;