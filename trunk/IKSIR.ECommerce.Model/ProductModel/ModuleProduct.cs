﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ModuleProduct : ModelBase
    {
        public Product Product { get; set; }
        public Module Module { get; set; }
        public string ProductName { get; set; }
        public string ModuleName { get; set; }
        public ModuleProduct(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,
            Product product, Module module)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Product = product;
            this.Module = module;
            this.ProductName = product.Title;
            this.ModuleName = module.Name;
        }

        public ModuleProduct()
        {
        }
    }
}
