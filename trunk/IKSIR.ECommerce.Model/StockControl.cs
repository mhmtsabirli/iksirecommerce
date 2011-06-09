using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class StockControl : ModelBase
    {
        public int StockId { get; set; }
        public int MinStock { get; set; }
        public DateTime AlertDate { get; set; }

        public StockControl(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int stockId, int minStock, DateTime alertDate)
            : base(id, createUserId, createDate, editUserId, editDate)
        {

            this.StockId = stockId;
            this.MinStock = minStock;
            this.AlertDate = alertDate;



        }

    }
}
