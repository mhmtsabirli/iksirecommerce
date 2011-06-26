using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IKSIR.ECommerce.Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        public static bool isNull(this object Object) 
        {
            if (Object == null)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
     
}
