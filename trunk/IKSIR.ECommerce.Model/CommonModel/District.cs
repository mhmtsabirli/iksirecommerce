using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class District : ModelBase
    {
        public City City { get; set; }
        public string Name { get; set; }

        public District(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, City city, string name)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.City = city;
            this.Name = name;
        }
    }
}
