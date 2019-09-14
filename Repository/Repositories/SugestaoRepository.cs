using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SugestaoRepository : ISugestaoRepository
    {
        public SistemaContext context;

        public SugestaoRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Sugestao sugestao)
        {
            Sugestao sugestaoOriginal = context.Sugestoes.FirstOrDefault(x => x.Id == sugestao.Id);
            if (sugestaoOriginal == null)
            {
                return false;
            }

            sugestaoOriginal.Nome = sugestao.Nome;
            sugestaoOriginal.Descricao = sugestao.Descricao;
            sugestaoOriginal.Ponto_Turistico = sugestao.Ponto_Turistico;
            sugestaoOriginal.Local = sugestao.Local;
            sugestaoOriginal.Cidade = sugestao.Cidade;
            sugestaoOriginal.Endereco = sugestao.Endereco;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var sugestao = context.Sugestoes.FirstOrDefault(x => x.Id == id);
            if (sugestao == null)
                return false;

            sugestao.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Cadastro(Sugestao sugestao)
        {
            sugestao.RegistroAtivo = true;
            context.Sugestoes.Add(sugestao);
            context.SaveChanges();
            return sugestao.Id;
        }

        public int Inserir(Sugestao sugestao)
        {
            sugestao.RegistroAtivo = true;
            context.Sugestoes.Add(sugestao);
            context.SaveChanges();
            return sugestao.Id;
        }

        public Sugestao ObterPeloId(int id)
        {
            return context.Sugestoes.FirstOrDefault(x => x.Id == id);
        }

        public List<Sugestao> ObterTodos()
        {
            return context.Sugestoes
                .Where(x => x.RegistroAtivo).ToList();
        }
    }
}
