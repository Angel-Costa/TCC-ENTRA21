using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IHotelRepository
    {
        int Cadastro(Hotel hotel);

        bool Alterar(Hotel hotel);

        List<Hotel> ObterTodos();

        Hotel ObterPeloId(int id);

        bool Apagar(int id);
    }
}
