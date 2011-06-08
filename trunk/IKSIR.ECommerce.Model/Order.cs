using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Order : Base
    {
        public int UserId { get; set; }
        public string Ip { get; set; }
        public string Host { get; set; }
        public string CargoNumber { get; set; }
        public string CargoName { get; set; }
        public int BillingAddressId { get; set; }
        public int EnumValueId { get; set; }
        public int PaymentOptionId { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int InvoiceId { get; set; }
        public int ShipmentAddressId { get; set; }
        public int PaymentType { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ShipmentDate { get; set; }

        public Order CreateOrder(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int userid, string ip, string host, string cargonumber,
            string cargoname, int billingaddressid, int enumvalueid, int paymentoptionid, decimal price, int tax, int invoiceid, int shipmmentaddressid,
            int paymenttype, int discount, int status, decimal totalprice, DateTime shipmmentdate)
        {
            Order o = new Order();
            o.UserId = userid;
            o.Ip = ip;
            o.Host = host;
            o.CargoNumber = cargonumber;
            o.CargoName = cargoname;
            o.BillingAddressId = billingaddressid;
            o.EnumValueId = enumvalueid;
            o.PaymentOptionId = paymentoptionid;
            o.Price = price;
            o.Tax = tax;
            o.InvoiceId = invoiceid;
            o.ShipmentAddressId = shipmmentaddressid;
            o.PaymentType = paymenttype;
            o.Discount = discount;
            o.Status = status;
            o.TotalPrice = totalprice;
            o.ShipmentDate = shipmmentdate;
            o.CreateBase(id, createuser, createdate, edituser, editdate);

            return o;
        }

    }
}
