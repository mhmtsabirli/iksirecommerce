using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class StaticPage : ModelBase
    {
        public SiteModel.Site Site { get; set; }
        public string Title { get; set; }
        public string PageContent { get; set; }

        public StaticPage(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, SiteModel.Site site, string title, string pageContent)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Site = site;
            this.Title = title;
            this.PageContent = pageContent;
        }
        public StaticPage()
        {
        }
    }
}
