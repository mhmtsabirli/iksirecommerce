using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class EnumValue : ModelBase
    {
        public int EnumId { get; set; }
        public string Value { get; set; }

        public EnumValue(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int enumId, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.EnumId = enumId;
            this.Value = value;
        }
        public EnumValue()
        {
        }
    }
}
