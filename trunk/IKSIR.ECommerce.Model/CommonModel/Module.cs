using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Module : ModelBase
    {
        public string Name { get; set; }
        public Site Site { get; set; }
        public Module(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string name,Site site )
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Name = name;
            this.Site = site;
        }

        public Module()
        {
            // TODO: Complete member initialization
        }
    }
}
