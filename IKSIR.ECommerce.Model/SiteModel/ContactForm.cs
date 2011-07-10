using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.SiteModel
{
    public class ContactForm : ModelBase
    {
	
        public string FirstLastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Solution { get; set; }
        public string StatusName { get; set; }
        public string Ip { get; set; }
        public EnumValue Status { get; set; }

        public ContactForm(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,string statusName,string firstLastName,string email,string title,string solution,string message,string ip,EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Email = email;
            this.FirstLastName = firstLastName;
            this.Ip = ip;
            this.Message = message;
            this.Status = status;
            this.Title = title;
            this.Solution = solution;
            this.StatusName = statusName;
        }
        public ContactForm()
        {
        }
    }
}
