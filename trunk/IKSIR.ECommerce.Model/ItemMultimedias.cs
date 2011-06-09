using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ItemMultimedias : ModelBase
    {
        public int ItemId { get; set; }
        public int Type { get; set; }
        public int ItemType { get; set; }

        public ItemMultimedias CreateItemMultimedias(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, int itemid, int type, int itemtype)
        {
            ItemMultimedias Im = new ItemMultimedias();
            Im.ItemId = itemid;
            Im.Type = type;
            Im.ItemType = itemtype;
            Im.CreateBase(id, createUserId, createdate, edituser, editdate);

            return Im;
        }
    }
}
