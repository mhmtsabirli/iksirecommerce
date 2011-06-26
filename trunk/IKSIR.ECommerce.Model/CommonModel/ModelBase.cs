using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class ModelBase
    {
        public int Id { get; set; }
        public int CreateAdminId { get; set; }
        public DateTime CreateDate { get; set; }
        public int EditAdminId { get; set; }
        public DateTime EditDate { get; set; }

        public ModelBase (int id, int createAdminId, DateTime createDate, int editAdminId, DateTime editDate)
        {
            this.Id = id;
            this.CreateAdminId = createAdminId;
            this.CreateDate = createDate;
            this.EditAdminId = editAdminId;
            this.EditDate = editDate;
        }
        public ModelBase()
        { 
            
        }
    }
}
