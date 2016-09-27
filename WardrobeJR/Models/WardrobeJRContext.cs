using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WardrobeJR.Models
{
    public class WardrobeJRContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WardrobeJRContext() : base("name=WardrobeJRContext")
        {
        }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Top> Tops { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Occasion> Occasions { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Season> Seasons { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Bottom> Bottoms { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Shoe> Shoes { get; set; }

        public System.Data.Entity.DbSet<WardrobeJR.Models.Outfit> Outfits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

    }
}
