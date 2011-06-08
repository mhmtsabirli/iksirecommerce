using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Country : Base
    {
        public string Name { get; set; }

        public Country CreateCountry(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,string name)
        {
            Country c = new Country();
            c.Name = name;
            c.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return c;
        }
    }
}
