using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class PropertyValue : ModelBase
    {
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public PropertyValue(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int propertyId, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            

            this.PropertyId = propertyId;
            this.Value = value;

            

            
        }
    }
}
