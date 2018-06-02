namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_photo_relation_created : DbMigration
    {
        public override void Up()
        {
            AddColumn("Production.Photo", "Product_Id", c => c.Int());
            CreateIndex("Production.Photo", "Product_Id");
            AddForeignKey("Production.Photo", "Product_Id", "Production.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Production.Photo", "Product_Id", "Production.Product");
            DropIndex("Production.Photo", new[] { "Product_Id" });
            DropColumn("Production.Photo", "Product_Id");
        }
    }
}
