using ConnectPlus.Models;

namespace ConnectPlus.Interfaces
{
    public interface IContatoRepository
    {
        List<Contato> Listar();

        void Deletar(Guid id);

        void Atualizar(Guid id, Contato contato);

        Contato BuscarPorId(Guid id);

        void Cadastra(TipoContato tipoContato);
    }
}
