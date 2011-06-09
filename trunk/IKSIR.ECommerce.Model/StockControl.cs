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

        public StockControl CreateStockControl(int id, int createUserId, DateTime createdate, int edituser, DateTime editdate, int stockid, int minstock, DateTime alertdate)
        {
            StockControl Sc = new StockControl();
            Sc.StockId = stockid;
            Sc.MinStock = minstock;
            Sc.AlertDate = alertdate;
            Sc.CreateBase(id, createUserId, createdate, edituser, editdate);

            return Sc;
        }

    }
}
