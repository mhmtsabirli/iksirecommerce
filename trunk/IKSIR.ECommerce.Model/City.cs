using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class City : Base
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public City CreateCity(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int counryid, string name)
        {
            City c = new City();
            c.CountryId = counryid;
            c.Name = name;
            c.CreateBase(id, createuser, createdate, edituser, editdate);

            return c;

        }

    }
}
