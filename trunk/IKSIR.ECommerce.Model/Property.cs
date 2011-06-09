using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Property : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Property(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title, string description)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.Title = title;
            this.Description = description;
     
        }
    }
}
