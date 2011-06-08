using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductCategories : Base
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategories CreateProductCategories(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int parentid, string title, string description)
        {
            ProductCategories Pc = new ProductCategories();
            Pc.ParentId = parentid;
            Pc.Title = title;
            Pc.Description = description;

            Pc.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return Pc;
        }
    }
}
