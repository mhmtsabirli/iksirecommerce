using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.SiteModel
{
    public class SiteModule : ModelBase
    {
        public Site Site { get; set; }
        public Module Module { get; set; }

        public SiteModule(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Site site, Module module)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Site = site;
            this.Module = module;
        }

        public SiteModule()
        {
        }
    }
}
