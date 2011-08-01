using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class Product : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int MinStock { get; set; }
        public string Video { get; set; }
        public EnumValue ProductStatus { get; set; }
        public int Guarantee { get; set; }
        public DateTime AlertDate { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductPrice ProductPrice { get; set; }
        public List<Multimedia> Multimedias { get; set; }
        public EnumValue StokStatus { get; set; }
        public int Stok { get; set; }
        public int MaxQuantity { get; set; }
        public string MainImage
        {
            get { return Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null ? Multimedias.Where(x => x.IsDefault == true).FirstOrDefault().FilePath : ""; }
        }
        public Product(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title,
            string description, string video, string productCode, EnumValue productStatus, EnumValue stokStatus, int stok, int maxQuantity, int guarantee, int minStock, DateTime alertdate, List<Multimedia> multimedias, ProductCategory productCategory, ProductPrice productPrice)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Video = video;
            this.Title = title;
            this.Description = description;
            this.ProductCode = productCode;
            this.ProductStatus = productStatus;
            this.MinStock = minStock;
            this.AlertDate = alertdate;
            this.ProductCategory = productCategory;
            this.ProductPrice = productPrice;
            this.Multimedias = multimedias;
            this.Guarantee = guarantee;
            this.StokStatus = stokStatus;
            this.Stok = stok;
            this.MaxQuantity = maxQuantity;
        }
        public Product()
        {
            // TODO: Complete member initialization
        }
    }

}
