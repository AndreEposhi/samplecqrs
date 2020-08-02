namespace SampleCqrs.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Numero = c.Int(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropTable("dbo.Pedido");
        }
    }
}
