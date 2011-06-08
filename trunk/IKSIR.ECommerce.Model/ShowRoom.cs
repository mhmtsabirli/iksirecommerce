using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ShowRoom : Base
    {
        public int ItemId { get; set; }
        public int EnumValueId { get; set; }

        public ShowRoom CreateShowRoom(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int itemid, int enumvalueid)
        {
            ShowRoom Sr = new ShowRoom();
            Sr.ItemId = itemid;
            Sr.EnumValueId = enumvalueid;
            Sr.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return Sr;
        }
    }
}
