using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ItemComments : ModelBase
    {

        public int ItemTypeId { get; set; }
        public int ItemId { get; set; }
        public int CommentId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }

        public ItemComments(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int itemTypeId, int itemId, int commentId, User user, bool isActive)
            : base(id, createUserId, createDate, editUserId, editDate)
        {

            this.ItemTypeId = itemTypeId;
            this.ItemId = itemId;
            this.CommentId = commentId;
            this.User = user;
            this.IsActive = isActive;
           

            
        }
    }
}
