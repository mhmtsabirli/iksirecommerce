using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.Management.Products
{
    public partial class ProductCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<IKSIR.ECommerce.Model.ProductModel.ProductCategory> pro = new List<Model.ProductModel.ProductCategory>();
            IKSIR.ECommerce.Model.ProductModel.ProductCategory a = new Model.ProductModel.ProductCategory();
            pro = ProductCategoryData.GetProductCategoryList(a);
            XmlSerializer MySerializer = new XmlSerializer(typeof(ProductCategoryData)); 
        }
    }
}


