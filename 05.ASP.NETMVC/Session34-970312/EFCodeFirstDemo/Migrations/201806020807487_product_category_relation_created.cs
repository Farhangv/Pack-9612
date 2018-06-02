namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_category_relation_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Production.Product_Category",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Code })
                .ForeignKey("Production.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("Production.Category", t => t.Category_Code, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Code);
            
            AddColumn("Production.Product", "Color", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("Production.Product_Category", "Category_Code", "Production.Category");
            DropForeignKey("Production.Product_Category", "Product_Id", "Production.Product");
            DropIndex("Production.Product_Category", new[] { "Category_Code" });
            DropIndex("Production.Product_Category", new[] { "Product_Id" });
            DropColumn("Production.Product", "Color");
            DropTable("Production.Product_Category");
        }
    }
}
