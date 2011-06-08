using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ItemComments : Base
    {
        public int ItemTypeId { get; set; }
        public int ItemId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public ItemComments CreateItemComments(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int itemtypeid, int itemid, int commentid, int userid, bool isactive)
        {
            ItemComments Ic = new ItemComments();
            Ic.ItemTypeId = itemtypeid;
            Ic.ItemId = itemid;
            Ic.CommentId = commentid;
            Ic.UserId = userid;
            Ic.IsActive = isactive;
            Ic.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return Ic;
        }
    }
}
