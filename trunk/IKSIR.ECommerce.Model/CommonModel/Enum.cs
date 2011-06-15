using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Enum : ModelBase
    {
        public string Name { get; set; }
        public List<EnumValue> EnumValue { get; set; }

        public Enum(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string name,List<EnumValue> enumValue)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Name = name;
            this.EnumValue = enumValue;
        }
        public Enum()
        {
        }
    }
}
