namespace IneqApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Armando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        Serie = c.String(),
                        Softtekld = c.String(),
                        Active = c.Boolean(nullable: false),
                        EquipmentTypeld = c.Int(nullable: false),
                        Modelld = c.Int(nullable: false),
                        Brandld = c.Int(nullable: false),
                        Statusld = c.Int(nullable: false),
                        Warehouseld = c.Int(nullable: false),
                        Brand_Id = c.Int(),
                        EquipmentType_ID = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.Brand_Id)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentType_ID)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.EquipmentType_ID)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IS = c.String(),
                        Responsable = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Brandld = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        ComponentTypeId = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                        EquipmentType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ComponentType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Components_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Component", t => t.Components_ID)
                .Index(t => t.Components_ID);
            
            CreateTable(
                "dbo.EquipmentType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UsefulLife = c.Single(nullable: false),
                        GuaranteeDuration = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WarehouseEquipment",
                c => new
                    {
                        Warehouse_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Warehouse_Id, t.Equipment_Id })
                .ForeignKey("dbo.Warehouse", t => t.Warehouse_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.Equipment_Id, cascadeDelete: true)
                .Index(t => t.Warehouse_Id)
                .Index(t => t.Equipment_Id);
            
            CreateTable(
                "dbo.ModelBrand",
                c => new
                    {
                        Model_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Model_Id, t.Brand_Id })
                .ForeignKey("dbo.Model", t => t.Model_Id, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_Id, cascadeDelete: true)
                .Index(t => t.Model_Id)
                .Index(t => t.Brand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Equipment", "EquipmentType_ID", "dbo.EquipmentType");
            DropForeignKey("dbo.ComponentType", "Components_ID", "dbo.Component");
            DropForeignKey("dbo.ModelBrand", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.ModelBrand", "Model_Id", "dbo.Model");
            DropForeignKey("dbo.Equipment", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.WarehouseEquipment", "Equipment_Id", "dbo.Equipment");
            DropForeignKey("dbo.WarehouseEquipment", "Warehouse_Id", "dbo.Warehouse");
            DropIndex("dbo.ModelBrand", new[] { "Brand_Id" });
            DropIndex("dbo.ModelBrand", new[] { "Model_Id" });
            DropIndex("dbo.WarehouseEquipment", new[] { "Equipment_Id" });
            DropIndex("dbo.WarehouseEquipment", new[] { "Warehouse_Id" });
            DropIndex("dbo.ComponentType", new[] { "Components_ID" });
            DropIndex("dbo.Equipment", new[] { "Status_Id" });
            DropIndex("dbo.Equipment", new[] { "EquipmentType_ID" });
            DropIndex("dbo.Equipment", new[] { "Brand_Id" });
            DropTable("dbo.ModelBrand");
            DropTable("dbo.WarehouseEquipment");
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.EquipmentType");
            DropTable("dbo.ComponentType");
            DropTable("dbo.Component");
            DropTable("dbo.Model");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Equipment");
            DropTable("dbo.Brand");
        }
    }
}
