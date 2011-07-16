﻿using System;
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
        public DateTime AlertDate { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductPrice ProductPrice { get; set; }

        public Product(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, string title,
            string description, string video, string productCode, int minStock, DateTime alertdate, ProductCategory productCategory,ProductPrice productPrice) 
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Video = video;
            this.Title = title;
            this.Description = description;
            this.ProductCode = productCode;
            this.MinStock = minStock;
            this.AlertDate = alertdate;
            this.ProductCategory = productCategory;
            this.ProductPrice = productPrice;
        }
        public Product()
        {
            // TODO: Complete member initialization
        }
    }
       
}
