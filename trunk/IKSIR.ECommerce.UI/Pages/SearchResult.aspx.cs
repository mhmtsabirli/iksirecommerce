using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.UI.ClassLibrary;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.Request.QueryString["searchkey"] != null && Page.Request.QueryString["searchkey"].ToString() != "")
                {
                    var searchkey = Page.Request.QueryString["searchkey"].ToString();
                    lblSearchKey.Text = searchkey;
                    lblSearchKey.ForeColor = System.Drawing.Color.Red;
                    GetSearchResult(searchkey);
                }
            }
        }

        private void GetSearchResult(string searchkey)
        {
            List<Product> productList = ModuleProductData.GetSearchResult(searchkey);
            if (productList.Count == 0)
            {
                lblNoResult.Visible = true;
                return;
            }
            int activePage = 0;
            if (Request.QueryString["p"] != null)
            {
                activePage = Int32.Parse(Request.QueryString["p"].ToString());
                activePage -= 1;
            }
            if (productList != null)
            {
                var pageCount = productList.Count / 6;
                if (productList.Count % 6 != 0)
                    pageCount += 1;

                if (pageCount > 1)
                {
                    Dictionary<string, string> pages = new Dictionary<string, string>();

                    for (int i = 1; i <= pageCount; i++)
                    {
                        pages.Add(i.ToString(), "SearchResult.aspx?searchkey=" + searchkey + "&p=" + i.ToString());
                    }

                    dlPaging.DataSource = pages;
                    dlPaging.DataBind();
                }
                productList = productList.Skip(6 * activePage).Take(6).ToList();
                dlProductList.DataSource = productList;
                dlProductList.DataBind();

                dlProductList.DataSource = productList;
                dlProductList.DataBind();

                foreach (DataListItem item in dlProductList.Items)
                {
                    Image imgProduct = (Image)item.FindControl("imgProduct");
                    HiddenField hdnProductId = (HiddenField)item.FindControl("hdnProductId");

                    if (imgProduct != null && hdnProductId != null)
                    {
                        int productId = 0;
                        if (hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                        {
                            imgProduct.ImageUrl = "";
                            var itemProduct = productList.Where(x => x.Id == productId).FirstOrDefault();
                            if (itemProduct != null && itemProduct.Multimedias != null && itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
                            {
                                var image = itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                                imgProduct.ImageUrl = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_" + image.FilePath;
                            }
                            else
                            {
                                imgProduct.ImageUrl = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_nopicture.jpg";
                            }

                        }
                    }
                }
            }
        }

        private void GetProductsForCategory(int categoryId)
        {
            List<Product> productList = ProductCategoryData.GetProductCategoryList(categoryId);
            int activePage = 0;
            if (Request.QueryString["p"] != null)
            {
                activePage = Int32.Parse(Request.QueryString["p"].ToString());
                activePage -= 1;
            }
            if (productList != null)
            {
                var pageCount = productList.Count / 6;
                if (productList.Count % 6 != 0)
                    pageCount += 1;

                if (pageCount > 1)
                {
                    Dictionary<string, string> pages = new Dictionary<string, string>();

                    for (int i = 1; i <= pageCount; i++)
                    {
                        pages.Add(i.ToString(), "ProductList.aspx?catid=" + categoryId.ToString() + "&p=" + i.ToString());
                    }

                    dlPaging.DataSource = pages;
                    dlPaging.DataBind();
                }
                productList = productList.Skip(6 * activePage).Take(6).ToList();
                dlProductList.DataSource = productList;
                dlProductList.DataBind();

                dlProductList.DataSource = productList;
                dlProductList.DataBind();

                foreach (DataListItem item in dlProductList.Items)
                {
                    Image imgProduct = (Image)item.FindControl("imgProduct");
                    HiddenField hdnProductId = (HiddenField)item.FindControl("hdnProductId");

                    if (imgProduct != null && hdnProductId != null)
                    {
                        int productId = 0;
                        if (hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                        {
                            imgProduct.ImageUrl = "";
                            var itemProduct = productList.Where(x => x.Id == productId).FirstOrDefault();
                            if (itemProduct != null && itemProduct.Multimedias != null && itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
                            {
                                var image = itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                                imgProduct.ImageUrl = "http://banyom.com.tr/documents/Images/Small/small_" + image.FilePath;
                            }
                            else
                            {
                                imgProduct.ImageUrl = "http://banyom.com.tr/documents/Images/Small/small_nopicture.jpg";
                            }

                        }
                    }
                }
            }
        }

        protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hplPageNo = e.Item.FindControl("hplPageNo") as HyperLink;

                if (hplPageNo != null && Page.Request.QueryString["p"] != null && Page.Request.QueryString["p"].ToString() != "" && hplPageNo.Text == Page.Request.QueryString["p"].ToString())
                {
                    hplPageNo.CssClass = "selectedpage";
                }
            }
        }

        protected void imgbtnAddtoBasket_Click(object sender, ImageClickEventArgs e)
        {
            int productId = 0;
            string strproductId = ((ImageButton)sender).CommandArgument;

            if (int.TryParse(strproductId, out productId))
                Shopping.AddToBasket(productId);
        }
    }
}