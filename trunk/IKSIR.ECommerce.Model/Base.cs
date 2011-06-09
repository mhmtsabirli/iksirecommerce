using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    public class ModelBase
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int EditUserId { get; set; }
        public DateTime EditDate { get; set; }

        public ModelBase (int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate)
        {
            this.Id = id;
            this.CreateUserId = createUserId;
            this.CreateDate = createDate;
            this.EditUserId = editUserId;
            this.EditDate = editDate;
        }
    }
}
