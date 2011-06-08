using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Multimedias : Base
    {
     public int   TypeId {get;set;}
     public string Value { get; set; }

     public Multimedias CreateMultimedias(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int typeid, string value)
     {
         Multimedias m = new Multimedias();
         m.TypeId = typeid;
         m.Value = value;
         m.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

         return m;
     }
    }
}
