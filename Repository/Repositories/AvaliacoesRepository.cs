using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class AvaliacoesRepository : IAvaliacoesRepository
    {
        public SistemaContext context;

        public AvaliacoesRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Avaliacao avaliacao)
        {
            context.Avaliacaos.Update(avaliacao);
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var avalicao = context.Avaliacaos.FirstOrDefault(x => x.Id == id);
            if (avalicao == null)
                return false;

            avalicao.RegistroAtivo = false;
            context.Avaliacaos.Update(avalicao);
            return context.SaveChanges() == 1;
        }

        public int Inserir(Avaliacao avaliacao)
        {
            context.Avaliacaos.Add(avaliacao);
            context.SaveChanges();
            return avaliacao.Id;
        }

        public Avaliacao ObterPeloId(int id)
        {
            return context.Avaliacaos.FirstOrDefault(x => x.Id == id);
        }

        public List<Avaliacao> ObterTodos()
        {
            return context.Avaliacaos.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
