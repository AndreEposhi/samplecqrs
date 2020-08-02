using SampleCqrs.Domain.Models.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SampleCqrs.Infra.Data.TypeConfigurations.Cadastro
{
    public class ClienteTypeConfiguration : EntityTypeConfiguration<Cliente>, IMapping
    {
        public ClienteTypeConfiguration()
        {
            ToTable("Cliente");
            HasKey(config => config.Id);
            Property(config => config.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(config => config.Nome).HasMaxLength(200).IsRequired();
            Property(config => config.Email).HasMaxLength(200).IsRequired();
            Property(config => config.DataCadastro).HasColumnType("date").IsRequired();
        }
    }
}