using ConnectPlus.Models;
using ConnectPlus.Repository;

namespace ConnectPlus.Interfaces
{
    public interface ITipoContatoRepository
    {
        void cadastra(TipoContato tipoContato);
        List<TipoContato> Listar();

        void Deletar(Guid id);

        void Atualizar(Guid id, TipoContato tipoContato);

        Contato BuscarPorId(Guid id);
     
    }
}
