using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class SystemLog : ModelBase
    {
        #region Properties
        public EnumValue Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        #endregion

        #region Constructors
        public SystemLog(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, EnumValue type, string title, string content)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Type = type;
            this.Title = title;
            this.Content = content;
        
        }

        public SystemLog()
        {
            // TODO: Complete member initialization
        }
        #endregion
    }
}
