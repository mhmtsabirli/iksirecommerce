using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    public class Base
    {
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int EditUser { get; set; }
        public DateTime EditDate { get; set; }

        public Base CreateBase(int id, int createuser, DateTime createdate, int edituser, DateTime editdate)
        {
            Base bs = new Base();
            bs.CreateDate = createdate;
            bs.CreateUser = createuser;
            bs.EditDate = editdate;
            bs.EditUser = edituser;
            bs.Id = id;

            return bs;
        }
    }
}
