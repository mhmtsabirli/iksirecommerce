using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Site : ModelBase
    {
        public string Name { get; set; }

        public Site(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string name)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Name = name;

            

            
        }
    }
}
