﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model.CommonModel
{
    class Multimedias : ModelBase
    {
        public EnumValue Type { get; set; }
        public string Value { get; set; }

        public Multimedias(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, EnumValue type, string value)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
