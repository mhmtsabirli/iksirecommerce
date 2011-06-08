using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class District : Base
    {
        public int CiyId { get; set; }
        public string Name { get; set; }

        public District CreateDistrict(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int cityid, string name)
        {
            District d = new District();
            d.CiyId=cityid;
            d.Name = name;
            d.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return d;

        }
    }
}
