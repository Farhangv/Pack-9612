namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productphoto_category_added : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Product");
            MoveTable(name: "dbo.Product", newSchema: "Production");
            CreateTable(
                "Production.Category",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "Production.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Production.Photo");
            DropTable("Production.Category");
            MoveTable(name: "Production.Product", newSchema: "dbo");
            RenameTable(name: "dbo.Product", newName: "Products");
        }
    }
}
