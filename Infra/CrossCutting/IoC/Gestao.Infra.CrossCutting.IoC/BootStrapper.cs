using Gestao.Domain.Interface.Repository;
using Gestao.Infra.Data.Context;
using Gestao.Infra.Data.Interfaces;
using Gestao.Infra.Data.Repositories;
using Gestao.Infra.Data.UnitOdWork;
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

            container.Register<GestaoContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, EfUnitOfWork>(Lifestyle.Scoped);


            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);

            //container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            //container.Register<IPessoaRepository, PessoaRepositoty>(Lifestyle.Scoped);
            //container.Register<ICidadeRepository, CidadesRepository>(Lifestyle.Scoped);

        }
    }
}