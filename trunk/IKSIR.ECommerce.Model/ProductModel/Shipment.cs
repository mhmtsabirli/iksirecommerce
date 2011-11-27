using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class Shipment : ModelBase
    {
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string Detail { get; set; }

        //public string Detail
        //{
        //    get { return this.Title + " / " + Utility.CurrencyFormat(this.UnitPrice) + " TL"; }
        //}
        public Shipment(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title,
            decimal unitPrice, string detail)
            : base(id, createUserId, createDate, editUserId, editDate)
        {

            this.Title = title;
            this.UnitPrice = unitPrice;
            this.Detail = detail;
        }
        public Shipment()
        {
            // TODO: Complete member initialization
        }
    }

}
