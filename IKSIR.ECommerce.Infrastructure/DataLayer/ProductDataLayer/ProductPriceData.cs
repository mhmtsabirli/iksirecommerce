using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.Bank;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductPriceData
    {
        public static ProductPrice Get(int ProductPriceId)
        {
            var returnValue = new ProductPrice();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", ProductPriceId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductPrice", parameters);
            while (dr.Read())
            {


                returnValue.Price = DBHelper.DecValue(dr["Price"].ToString());
                returnValue.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                returnValue.Tax = DBHelper.IntValue(dr["Tax"].ToString());
                returnValue.Product = ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.ProductShipmentPrice = ProductShipmentPriceData.GetByProduct(DBHelper.IntValue(dr["ProductId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static ProductPrice GetByProduct(int ProductId)
        {
            var returnValue = new ProductPrice();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", ProductId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductPrice", parameters);

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {


                    returnValue.Price = DBHelper.DecValue(dr["Price"].ToString());
                    returnValue.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                    returnValue.Tax = DBHelper.IntValue(dr["Tax"].ToString());
                    returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                    returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                    returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                    returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                    returnValue.ProductShipmentPrice = ProductShipmentPriceData.GetByProduct(DBHelper.IntValue(dr["ProductId"].ToString()));
                }
            }
            else
            {
                returnValue.Price = DBHelper.DecValue(0);
                returnValue.UnitPrice = DBHelper.DecValue(0);
                returnValue.Tax = DBHelper.IntValue(0);
                returnValue.CreateAdminId = DBHelper.IntValue(0);
                returnValue.EditAdminId = DBHelper.IntValue(0);
                returnValue.Id = DBHelper.IntValue(0);
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(ProductPrice productPrice)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(productPrice.Product.Id)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(productPrice.Price)));
            parameters.Add(new SqlParameter("@Tax", DBHelper.IntValue(productPrice.Tax)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(productPrice.UnitPrice)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(productPrice.CreateAdminId)));


            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductPrice", parameters));
            return returnValue;
        }

        public static int Update(ProductPrice productPrice)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(productPrice.Product.Id)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(productPrice.Price)));
            parameters.Add(new SqlParameter("@Tax", DBHelper.IntValue(productPrice.Tax)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(productPrice.UnitPrice)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(productPrice.EditAdminId)));
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(productPrice.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProductPrice", parameters);
            return returnValue;
        }

        public static int Delete(int Id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProductPrice", parameters);
            return returnValue;
        }

        public static List<ProductPrice> GetProductPriceList()
        {
            List<ProductPrice> itemProductPrice = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductPrice", parameters);
            itemProductPrice = new List<ProductPrice>();

            while (dr.Read())
            {
                var item = new ProductPrice();
                item.Price = DBHelper.DecValue(dr["Price"].ToString());
                item.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                item.Tax = DBHelper.IntValue(dr["Tax"].ToString());
                item.Product = ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.ProductShipmentPrice = ProductShipmentPriceData.GetByProduct(DBHelper.IntValue(dr["ProductId"].ToString()));
                itemProductPrice.Add(item);
            }

            dr.Close();
            return itemProductPrice;
        }

        public static List<CreditCardRates> GetCalculatedPriceList(decimal Price)
        {
            List<CreditCardRates> creditCardRatesList = new List<CreditCardRates>();
            List<CreditCard> creditCardList = null;
            List<PaymetTermRate> paymentTermRateList = null;
            creditCardList = CreditCardData.GetAktiveCreditCardList();

            foreach (CreditCard creditCard in creditCardList)
            {
                var creditCardRates = new CreditCardRates();
                var RateList = new List<Rates>();
                creditCardRates.CreditCardImage = creditCard.Image;
                creditCardRates.CreditCardName = creditCard.Name;
                creditCardRates.BankName = creditCard.Bank.Name;
                paymentTermRateList = PaymetTermRateData.GetAktivePaymetTermRateList(creditCard.Id);

                foreach (PaymetTermRate paymentTermRate in paymentTermRateList)
                {
                    var rate = new Rates();
                    rate.Month = paymentTermRate.Month;
                    rate.Price = DBHelper.DecValue((paymentTermRate.Rate * Price));
                    RateList.Add(rate);
                }
                creditCardRates.Rates = RateList;

                creditCardRatesList.Add(creditCardRates);
            }


            return creditCardRatesList;
        }
    }
}
