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

        public ItemMultimedias(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int itemId, int type, int itemType)
            : base(id, createUserId, createDate, editUserId, editDate)
        {

            this.ItemId = itemId;
            this.Type = type;
            this.ItemType = itemType;

        }
    }
}
