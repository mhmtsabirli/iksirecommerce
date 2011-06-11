using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.ShoppingModel
{
    public class Order : ModelBase
    {
        public User User { get; set; }
        public string Ip { get; set; }
        public string Host { get; set; }
        public string CargoNumber { get; set; }
        public string CargoName { get; set; }
        public Address BillingAddress { get; set; }
        public EnumValue EnumValue { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public Invoice Invoice { get; set; }
        public Address ShipmentAddress { get; set; }
        public int PaymentType { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ShipmentDate { get; set; }

        public Order(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, User user, string ip, string host, string cargoNumber,
            string cargoName, Address billingAddress, EnumValue enumValue, PaymentOption paymentOption, decimal price, int tax, Invoice invoice, Address shipmmentAddress,
            int paymenttype, int discount, int status, decimal totalprice, DateTime shipmmentDate)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.User = user;
            this.Ip = ip;
            this.Host = host;
            this.CargoNumber = cargoNumber;
            this.CargoName = cargoName;
            this.BillingAddress = billingAddress;
            this.EnumValue = enumValue;
            this.PaymentOption = paymentOption;
            this.Price = price;
            this.Tax = tax;
            this.Invoice = invoice;
            this.ShipmentAddress = shipmmentAddress;
            this.PaymentType = paymenttype;
            this.Discount = discount;
            this.Status = status;
            this.TotalPrice = totalprice;
            this.ShipmentDate = shipmmentDate;
        }
    }
}
