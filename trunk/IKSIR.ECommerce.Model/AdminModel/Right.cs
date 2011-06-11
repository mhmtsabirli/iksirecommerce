using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.AdminModel
{
    class Right : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Right(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
