using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class ItemComments : ModelBase
    {

        public EnumValue ItemType { get; set; }
        public int ItemId { get; set; }
        public int CommentId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }

        public ItemComments(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, EnumValue itemType, int itemId, int commentId, User user, bool isActive)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.ItemType = itemType;
            this.ItemId = itemId;
            this.CommentId = commentId;
            this.User = user;
            this.IsActive = isActive;
        }
        public ItemComments()
        {
        }
    }
}
