using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Application.Interface
{
    public interface IAppServiceBase
    {
        void BeginTransaction();
        void Commit();
    }
}
