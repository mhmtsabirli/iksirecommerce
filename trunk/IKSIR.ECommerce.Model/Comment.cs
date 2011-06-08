using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Comment : Base
    {
        public int UserId { get; set; }
        public string value { get; set; }
        public string Ip { get; set; }
        public int Website { get; set; }

        public Comment CreateComment(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int userid, string value, string ip, int website)
        {
            Comment c = new Comment();
            c.UserId = userid;
            c.value = value;
            c.Ip = ip;
            c.Website = website;
            c.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return c;
        }
    }
}
