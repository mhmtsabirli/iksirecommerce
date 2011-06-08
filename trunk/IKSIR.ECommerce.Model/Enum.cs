using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Enum : Base
    {
        public string Name { get; set; }

        public Enum CreateEnum(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, string name)
        {
            Enum e = new Enum();
            e.Name = name;
            e.CreateBase(id, createuser, createdate, edituser, editdate);

            return e;
        }
    }
}
