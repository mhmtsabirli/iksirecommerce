using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Right : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Right CreateRight(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, string title, string description)
        {
            Right r = new Right();
            r.Title = title;
            r.Description = description;
            r.CreateBase(id, createuser, createdate, edituser, editdate);

            return r;
        }
    }
}
