namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productid_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Production.Photo", "Product_Id", "Production.Product");
            DropIndex("Production.Photo", new[] { "Product_Id" });
            RenameColumn(table: "Production.Photo", name: "Product_Id", newName: "ProductId");
            AlterColumn("Production.Photo", "ProductId", c => c.Int(nullable: false));
            CreateIndex("Production.Photo", "ProductId");
            AddForeignKey("Production.Photo", "ProductId", "Production.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Production.Photo", "ProductId", "Production.Product");
            DropIndex("Production.Photo", new[] { "ProductId" });
            AlterColumn("Production.Photo", "ProductId", c => c.Int());
            RenameColumn(table: "Production.Photo", name: "ProductId", newName: "Product_Id");
            CreateIndex("Production.Photo", "Product_Id");
            AddForeignKey("Production.Photo", "Product_Id", "Production.Product", "Id");
        }
    }
}
