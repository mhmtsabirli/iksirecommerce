using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class PropertyValue : Base
    {
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public PropertyValue CreatePropertyValue(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int propertyid, string value)
        {
            PropertyValue Pv = new PropertyValue();

            Pv.PropertyId = propertyid;
            Pv.Value = value;

            Pv.CreateBase(id, createuser, createdate, edituser, editdate);

            return Pv;
        }
    }
}
