using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class City : ModelBase
    {
        public Country Country { get; set; }
        public string Name { get; set; }

        public City(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Country country, string name)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Country = country;
            this.Name = name;
        }
    }
}
