using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Property : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Property CreateProperty(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,string title, string description)
        {
            Property p = new Property();
            p.Title = title;
            p.Description = description;
            p.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return p;
        }
    }
}
