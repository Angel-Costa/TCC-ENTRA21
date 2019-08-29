using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public SistemaContext context;
        
        public HotelRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Hotel hotel)
        {
            Hotel hotelOriginal = context.Hoteis.FirstOrDefault(x => x.Id == hotel.Id);
            if(hotelOriginal == null)
            {
                return false;
            }

            hotelOriginal.Nome = hotel.Nome;
            hotelOriginal.Descricao = hotel.Descricao;
            hotelOriginal.ValorNoite = hotel.ValorNoite;
            hotelOriginal.Estado = hotel.Estado;
            hotelOriginal.Cidade = hotel.Cidade;
            hotelOriginal.CEP = hotel.CEP;
            hotelOriginal.Bairro = hotel.Bairro;
            hotelOriginal.Numero = hotel.Numero;
            hotelOriginal.Rua = hotel.Rua;
            hotelOriginal.Complemento = hotel.Complemento;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var hotel = context.Hoteis.FirstOrDefault(y => y.Id == id);
            if (hotel == null)
                return false;

            hotel.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Hotel hotel)
        {
            hotel.RegistroAtivo = true;
            context.Hoteis.Add(hotel);
            context.SaveChanges();
            return hotel.Id;
        }

        public Hotel ObterPeloId(int id)
        {
            return context.Hoteis.FirstOrDefault(x => x.Id == id);
        }

        public List<Hotel> ObterTodos()
        {
            return context.Hoteis
                .Where(x => x.RegistroAtivo).ToList();
        }
    }
}
