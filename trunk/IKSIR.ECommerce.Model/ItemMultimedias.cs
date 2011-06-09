using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ItemMultimedias : ModelBase
    {
        public int ItemId { get; set; }
        public EnumValue Type { get; set; }
        public EnumValue ItemType { get; set; }

        public ItemMultimedias(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int itemId, EnumValue type, EnumValue itemType)
            : base(id, createUserId, createDate, editUserId, editDate)
        {

            this.ItemId = itemId;
            this.Type = type;
            this.ItemType = itemType;

        }
    }
}
