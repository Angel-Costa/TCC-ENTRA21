using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        public SistemaContext context;

        public ContatoRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Contato contato)
        {
            Contato contatoOriginal = context.Contatos.FirstOrDefault(x => x.Id == contato.Id);
            if (contatoOriginal == null)
            {
                return false;
            }

            contatoOriginal.Nome = contato.Nome;
            contatoOriginal.Email = contato.Email;
            contatoOriginal.Celular = contato.Celular;
            contatoOriginal.Mensagem = contato.Mensagem;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var contato = context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
                return false;

            contato.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Contato contato)
        {
            context.Contatos.Add(contato);
            context.SaveChanges();
            return contato.Id;
        }

        public Contato ObterPeloId(int id)
        {
            return context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<Contato> ObterTodos()
        {
            return context.Contatos.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
