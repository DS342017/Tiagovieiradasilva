﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Web_APIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Web_APIContext() : base("name=Web_APIContext")
        {
        }

        public System.Data.Entity.DbSet<Web_API.Models.Modelo_Pedido> Modelo_Pedido { get; set; }
    }
}
