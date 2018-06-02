namespace EFCodeFirstDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopModel : DbContext
    {
        public ShopModel()
            //: base("name=ShopModel")
            //: base("data source=.;database=ShopDb;uid=sa;pwd=developer;")
            : base("ShopModel")
        {
        }


        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Color)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(m => m.ToTable("Product_Category", "Production"));
        }
    }

}