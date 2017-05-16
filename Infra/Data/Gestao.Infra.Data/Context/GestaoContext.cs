using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gestao.Infra.Data.Context
{
    public class GestaoContext : DbContext
    {

        public GestaoContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //public IDbSet<Cidade> Cidadess { get; set; }
        //public IDbSet<Usuario> Usuarios { get; set; }
        //public IDbSet<Pessoa> Pessoas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new CidadesConfiguration());
            //modelBuilder.Configurations.Add(new PessoaConfiguration());
            //modelBuilder.Configurations.Add(new UsuarioConfiguration());
            //modelBuilder.Configurations.Add(new AlunoConfiguration());
            //modelBuilder.Configurations.Add(new AlunoHistoricoConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
