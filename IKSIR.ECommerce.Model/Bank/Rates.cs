using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Bank
{
    public class Rates : ModelBase
    {

        public decimal Price { get; set; }
        public int Month { get; set; }


        public Rates(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            int month, decimal price)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Price = price;
            this.Month = month;
        }

        public Rates()
        {
        }
    }
}
