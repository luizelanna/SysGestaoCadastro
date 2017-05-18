using System;
using System.Collections.Generic;
using System.Linq;
using Gestao.Domain.Entities;
using Gestao.Domain.Interface.Repository;
using Gestao.Infra.Data.Context;

namespace Gestao.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestaoContext _db;

        public UsuarioRepository()
        {
            _db = new GestaoContext();
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.ToList();
        }
        public void DesativarLock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}