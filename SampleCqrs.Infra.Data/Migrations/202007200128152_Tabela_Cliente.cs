namespace SampleCqrs.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 200),
                        Nome = c.String(nullable: false, maxLength: 200),
                        DataCadastro = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
