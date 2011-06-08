using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductProperties : Base
    {
        public int PropertyId { get; set; }
        public int ProductId { get; set; }

        public ProductProperties CreateProductProperties(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int propertyid, int productid)
        {
            ProductProperties Pp = new ProductProperties();
            Pp.PropertyId = propertyid;
            Pp.ProductId = productid;

            Pp.CreateBase(id, createuser, createdate, edituser, editdate);

            return Pp;
        }
    }
}
;