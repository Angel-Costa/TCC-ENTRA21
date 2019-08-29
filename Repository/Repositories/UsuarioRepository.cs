using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private SistemaContext context;

        public UsuarioRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Usuario usuario)
        {
            Usuario usuarioOriginal = context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            if (usuarioOriginal == null)
            {
                return false;
            }

            usuarioOriginal.Nome = usuario.Nome;
            usuarioOriginal.Cpf = usuario.Cpf;
            usuarioOriginal.Login = usuario.Login;
            usuarioOriginal.Senha = usuario.Senha;

            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(y => y.Id == id);
            if (usuario == null)
                return false;

            usuario.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Usuario usuario)
        {
            usuario.RegistroAtivo = true;
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return usuario.Id;
        }

        public Usuario ObterPeloId(int id)
        {
            return context.Usuarios.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
        }

        public List<Usuario> ObterTodos()
        {
            return context.Usuarios
                .Where(x => x.RegistroAtivo).ToList().ToList();
        }
    }

    
}
