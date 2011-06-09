using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ShowRoom : ModelBase
    {
        public Product Item { get; set; }
        public EnumValue EnumValue { get; set; }

        public ShowRoom(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Product item, EnumValue enumValue)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Item = item;
            this.EnumValue = enumValue;
            

            
        }
    }
}
