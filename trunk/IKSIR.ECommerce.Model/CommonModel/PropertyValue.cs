using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    class PropertyValue : ModelBase
    {
        public Property Property { get; set; }
        public string Value { get; set; }

        public PropertyValue(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Property property, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Property = property;
            this.Value = value;
        }
    }
}
