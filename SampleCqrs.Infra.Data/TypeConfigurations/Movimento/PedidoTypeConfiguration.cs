using SampleCqrs.Domain.Models.Movimento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SampleCqrs.Infra.Data.TypeConfigurations.Movimento
{
    public class PedidoTypeConfiguration : EntityTypeConfiguration<Pedido>, IMapping
    {
        public PedidoTypeConfiguration()
        {
            ToTable("Pedido");
            HasKey(map => map.Id);
            Property(map => map.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(map => map.Numero).IsRequired();
            Property(map => map.ClienteId);

            HasRequired(map => map.Cliente)
                .WithMany(map => map.Pedidos)
                .HasForeignKey(map => map.ClienteId);
        }
    }
}