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
        public string EnumName { get; set; }

        public EnumValue(int id, int createUserId, DateTime createDate, int editUserId,string enumName, DateTime editDate, int enumId, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.EnumId = enumId;
            this.Value = value;
            this.EnumName = enumName;
        }
        public EnumValue()
        {
        }
    }
}
