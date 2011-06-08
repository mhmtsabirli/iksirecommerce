using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class EnumValues : Base
    {
        public int EnumId {get;set;}
        public string Value { get; set; }

        public EnumValues CreateEnumValues(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int enumid, string value)
        {
            EnumValues ev = new EnumValues();
            ev.EnumId = enumid;
            ev.Value = value;

            ev.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return ev;
        }
    }
}
