using System;
using System.Collections.Generic;
using Gestao.Domain.Entities;

namespace Gestao.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}