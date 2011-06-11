using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    class Property : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PropertyValue> PropertyValue { get; set; }

        public Property(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title, string description,List<PropertyValue> propertyValue)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Title = title;
            this.Description = description;
            this.PropertyValue = propertyValue;
        }
    }
}
