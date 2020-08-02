using SampleCqrs.Domain.Models.Cadastro;
using SampleCqrs.Domain.Models.Movimento;
using SampleCqrs.Infra.Data.TypeConfigurations;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace SampleCqrs.Infra.Data.Contexts
{
    public class SampleCqrsDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public SampleCqrsDbContext() : base("SampleCqrsDbContext")
        { }

        public SampleCqrsDbContext(string connectionString) : base(connectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ClienteTypeConfiguration());
            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();
            // Varrendo todos os tipos que são mapeamento
            // Com ajuda do Reflection criamos as instancias
            // e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}