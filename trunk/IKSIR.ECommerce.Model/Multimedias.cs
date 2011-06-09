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

     public Multimedias CreateMultimedias(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate,int typeid, string value)
     {
         Multimedias m = new Multimedias();
         m.TypeId = typeid;
         m.Value = value;
         m.CreateBase( id,  createUserId,  createdate,  edituser,  editdate);

         return m;
     }
    }
}
