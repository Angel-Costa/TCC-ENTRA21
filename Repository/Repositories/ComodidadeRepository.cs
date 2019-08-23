using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ComodidadeRepository : IComodidadeRepository
    {
        public SistemaContext context;

        public ComodidadeRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Comodidade comodidade)
        {
            context.Comodidades.Update(comodidade);
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var comodidade = context.Comodidades.FirstOrDefault(x => x.Id == id);
            if (comodidade == null)
                return false;

            comodidade.RegistroAtivo = false;
            context.Comodidades.Update(comodidade);
            return context.SaveChanges() == 1;

        }

        public int Inserir(Comodidade comodidade)
        {
            context.Comodidades.Add(comodidade);
            context.SaveChanges();
            return comodidade.Id;
        }

        public Comodidade ObterPeloId(int id)
        {
            return context.Comodidades.FirstOrDefault(x => x.Id == id);
        }

        public List<Comodidade> ObterTodos()
        {
            return context.Comodidades.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
