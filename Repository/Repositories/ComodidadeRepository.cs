using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ComodidadeRepository : IComodidadeRepository
    {
        public SistemaContext context;

        public ComodidadeRepository()
        {
            this.context = new SistemaContext();
        }

        /* hotel.RegistroAtivo = true;
            context.Hoteis.Add(hotel);
            context.SaveChanges();
            return hotel.Id;
        */
        public bool Alterar(Comodidade comodidade)
        {
            Comodidade comodidadeOriginal = context.Comodidades.FirstOrDefault(x => x.Id == comodidade.Id);
            if(comodidadeOriginal == null)
            {
                return false;
            }

            comodidadeOriginal.Nome = comodidade.Nome;
            comodidadeOriginal.IdHotel = comodidade.IdHotel;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var comodidade = context.Comodidades.FirstOrDefault(x => x.Id == id);
            if (comodidade == null)
                return false;

            comodidade.RegistroAtivo = false;
            return context.SaveChanges() == 1;

        }        

        public int Inserir(Comodidade comodidade)
        {            
            comodidade.RegistroAtivo = true;
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
            return context.Comodidades
                .Include("Hotel")
                .Where(x => x.RegistroAtivo)
                .ToList();
        }
    }
}
