using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Invoice : Base
    {
        public int OrderId { get; set; }
        public string InvoiceNumber { get; set; }
        public int Status { get; set; }
        public DateTime InvoiceDate { get; set; }

        public Invoice CreateInvoice(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int orderid, string invoicenumber, int status, DateTime invoicedate)
        {
            Invoice I = new Invoice();
            I.OrderId = orderid;
            I.InvoiceDate = invoicedate;
            I.Status = status;
            I.InvoiceDate = invoicedate;
            I.CreateBase( id,  createuser,  createdate,  edituser,  editdate);

            return I;
        }
    }
}
