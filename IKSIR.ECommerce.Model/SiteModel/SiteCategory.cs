using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.SiteModel
{
    public class SiteCategory : ModelBase
    {
        public Site Site { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public SiteCategory(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Site site, ProductCategory productCategory)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Site = site;
            this.ProductCategory = productCategory;
        }

        public SiteCategory()
        {
        }
    }
}
