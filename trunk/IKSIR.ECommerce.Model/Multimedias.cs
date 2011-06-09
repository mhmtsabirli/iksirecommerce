using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Multimedias : ModelBase
    {
     public int   TypeId {get;set;}
     public string Value { get; set; }

     public Multimedias(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int typeId, string value)
         : base(id, createUserId, createDate, editUserId, editDate)
     {

         this.TypeId = typeId;
         this.Value = value;
        

        
     }
    }
}
