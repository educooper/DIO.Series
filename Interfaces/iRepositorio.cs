using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface iRepositorio<T>
    {
         List <T> lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T endidade);
         int ProximoId();


    }
}