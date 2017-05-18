using Gestao.Domain.Interface.Repository;
using Gestao.Infra.CrossCutting.Identity.Configuration;
using Gestao.Infra.CrossCutting.Identity.Context;
using Gestao.Infra.CrossCutting.Identity.Model;
using Gestao.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace Gestao.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //container.Register<ICidadeAppService, CidadeAppService>(Lifestyle.Scoped);
            //container.Register<IPessoaAppService, PessoaAppService>(Lifestyle.Scoped);
            //container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);

            //container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            //container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);
            //container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);

            //container.Register<GestaoContext>(Lifestyle.Scoped);
            //container.Register<IUnitOfWork, EfUnitOfWork>(Lifestyle.Scoped);


            //container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);

            container.Register<ApplicationDbContext>();
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.Register<ApplicationRoleManager>();
            container.Register<ApplicationUserManager>();

            container.Register<ApplicationSignInManager>();



            //container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            //container.Register<IPessoaRepository, PessoaRepositoty>(Lifestyle.Scoped);
            //container.Register<ICidadeRepository, CidadesRepository>(Lifestyle.Scoped);

        }
    }
}