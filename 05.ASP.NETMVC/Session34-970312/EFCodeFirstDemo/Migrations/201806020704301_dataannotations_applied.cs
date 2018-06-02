namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotations_applied : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Production.Product", name: "ListPrice", newName: "Price");
            AlterColumn("Production.Category", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Production.Photo", "Title", c => c.String(maxLength: 50));
            AlterColumn("Production.Photo", "Path", c => c.String(maxLength: 150));
            AlterColumn("Production.Product", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("Production.Product", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Production.Product", new[] { "Name" });
            AlterColumn("Production.Product", "Name", c => c.String());
            AlterColumn("Production.Photo", "Path", c => c.String());
            AlterColumn("Production.Photo", "Title", c => c.String());
            AlterColumn("Production.Category", "Name", c => c.String());
            RenameColumn(table: "Production.Product", name: "Price", newName: "ListPrice");
        }
    }
}
