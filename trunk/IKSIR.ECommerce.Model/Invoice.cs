using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Invoice : ModelBase
    {
        public Order Order { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Status { get; set; }

        public Invoice(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Order order, string invoiceNumber, DateTime invoiceDate, int status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Order = order;
            this.InvoiceNumber = invoiceNumber;
            this.InvoiceDate = invoiceDate;
            this.Status = status;
        }
    }
}
