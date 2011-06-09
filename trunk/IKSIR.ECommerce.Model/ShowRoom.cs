using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ShowRoom : ModelBase
    {
        public int ItemId { get; set; }
        public int EnumValueId { get; set; }

        public ShowRoom CreateShowRoom(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate,int itemid, int enumvalueid)
        {
            ShowRoom Sr = new ShowRoom();
            Sr.ItemId = itemid;
            Sr.EnumValueId = enumvalueid;
            Sr.CreateBase( id,  createUserId,  createdate,  edituser,  editdate);

            return Sr;
        }
    }
}
