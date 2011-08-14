using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Comment : ModelBase
    {
        public Product Product { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Ip { get; set; }
        public Site Site { get; set; }
        public EnumValue Status { get; set; }        

        public Comment(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Product product, User user, string title, string content, string ip, Site site, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Product = product;
            this.User = user;
            this.Title = title;
            this.Content = content;
            this.Ip = ip;
            this.Site = site;
            this.Status = status;
        }
        public Comment()
        {
        }
    }
}
