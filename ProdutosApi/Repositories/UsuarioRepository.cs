using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutosApi.Model;
using ProdutosApi.DataBase;

namespace UsuariosApi.Repositories
{
    public class UsuarioRepository : IDisposable
    {
        private Context _context;

        public UsuarioRepository()
        {
            _context = new Context();
        }

        public void Add(Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
        }

        public void Remove(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario Usuario)
        {
            _context.Usuarios.Update(Usuario);
            _context.SaveChanges();
        }

        public Usuario Find(int id)
        {
            Usuario Usuario = (Usuario) _context.Usuarios.Where(p => p.Id == id).FirstOrDefault();
            return Usuario;
        }


        public IList<Usuario> GetAll()
        {
            IList<Usuario> Usuarios = (IList<Usuario>) _context.Usuarios.ToList();
            return Usuarios;
        }


        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }

    }

}
