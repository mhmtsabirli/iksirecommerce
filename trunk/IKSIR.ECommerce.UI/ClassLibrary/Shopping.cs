using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.ClassLibrary
{
    public class Shopping
    {
        //UI tarfında sepete ürün eklemek için kullanılır.
        public static void AddToBasket(int productId, int count = 1)
        {
            if (HttpContext.Current.Session["USER_BASKET"] == null)
            {
                //Sessionda basket yoksa yeni basket oluştur.
                Basket basket = new Basket();
                BasketItem basketItem = new BasketItem();
                basketItem.Product = ProductData.Get(productId);
                basketItem.ProductPrice = ProductPriceData.GetByProduct(productId);
                basketItem.Count = count;
                basket.BasketItems = new List<BasketItem>();
                basket.BasketItems.Add(basketItem);
                HttpContext.Current.Session.Add("USER_BASKET", basket);
            }
            else
            {
                //Sessionda basket varsa.
                Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];

                BasketItem existBasketItem = basket.BasketItems.Where(x => x.Product.Id == productId).FirstOrDefault();

                if (existBasketItem != null && existBasketItem.Count > 0)
                {
                    //basket.BasketItems.Remove(existBasketItem);
                    basket.BasketItems.Where(x => x.Product.Id == productId).FirstOrDefault().Count = count;
                }
                else
                {
                    BasketItem basketItem = new BasketItem();
                    basketItem.Product = ProductData.Get(productId);
                    basketItem.ProductPrice = ProductPriceData.GetByProduct(productId);
                    basketItem.Count = count;
                    basket.BasketItems.Add(basketItem);
                }
                HttpContext.Current.Session.Add("USER_BASKET", basket);
            }
            HttpContext.Current.Response.Redirect("../Pages/OrderBasket.aspx", false);
            if (HttpContext.Current.Session["LOGIN_USER"] == null)
            {
                //Ürünü sepetine eklemek isterken login mi? Değilse login sayfasına yönlendir.
                HttpContext.Current.Response.Redirect("../Pages/Login.aspx?returl=OrderBasket.aspx", false);
            }
        }

        public static void RemoveBasketItem(int productId)
        {
            if (HttpContext.Current.Session["LOGIN_USER"] == null)
            {
                //Ürünü sepetine eklemek isterken login mi? Değilse login sayfasına yönlendir.
                HttpContext.Current.Response.Redirect("../Pages/Login.aspx", false);
            }
            else
            {
                if (HttpContext.Current.Session["USER_BASKET"] != null)
                {
                    //Sessionda basket varsa.
                    Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    BasketItem existBasketItem = basket.BasketItems.Where(x => x.Product.Id == productId).FirstOrDefault();

                    if (existBasketItem != null)
                    {
                        basket.BasketItems.Remove(existBasketItem);
                    }

                    HttpContext.Current.Session.Add("USER_BASKET", basket);
                }
                HttpContext.Current.Response.Redirect("../Pages/OrderBasket.aspx", false);
            }
        }

        public static void GetBasket(ref int itemCount)
        {
            if (HttpContext.Current.Session["USER_BASKET"] != null)
            {
                Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                itemCount = basket.BasketItems.Count;
            }
        }
    }
}