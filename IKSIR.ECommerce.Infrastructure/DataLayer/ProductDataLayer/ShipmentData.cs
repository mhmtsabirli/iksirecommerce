using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ShipmentData
    {
        public static Shipment Get(int SchipmentId)
        {
            var returnValue = new Shipment();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", SchipmentId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetShipment", parameters);
            while (dr.Read())
            {
                

                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Shipment shipment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(shipment.Title)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(shipment.UnitPrice)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(shipment.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertShipment", parameters));
            return returnValue;
        }

        public static int Update(Shipment shipment)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(shipment.Title)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(shipment.UnitPrice)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(shipment.EditAdminId)));
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(shipment.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateShipment", parameters);
            return returnValue;
        }

        public static int Delete(int Id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteShipment", parameters);
            return returnValue;
        }

        public static List<Shipment> GetShipmentList()
        {
            List<Shipment> itemShipment = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetShipment", parameters);
            itemShipment = new List<Shipment>();

            while (dr.Read())
            {
                var item = new Shipment();
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                itemShipment.Add(item);
            }

            dr.Close();
            return itemShipment;
        }

    }
}
