using ConnectPlus.BdContexConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repository
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _Connect;

        public TipoContatoRepository(ConnectContext connect)
        {
            _Connect = connect;
        }

       

        public void Atualizar(Guid id, TipoContato tipoContato)
        {
            var ContatoBuscado = _Connect.TipoContatos.Find(id);
            if (ContatoBuscado != null)
            {
                ContatoBuscado.Nome = tipoContato.Nome;
                ContatoBuscado.Email = tipoContato.Email;

                _Connect.SaveChanges();

            }
        }

        public Contato BuscarPorId(Guid id, object lista)
        {
            throw new NotImplementedException();
        }

        public void cadastra(TipoContato tipoContato)
        {
            _Connect.TipoContatos.Add(tipoContato);
            _Connect.SaveChanges();
        }

        public TipoContato BuscarPorId(Guid id)
        {
            return _Connect.TipoContatos.Find(id);
        }

        void ITipoContatoRepository.Deletar(Guid id)
        {
            var ContatoBuscado = _Connect.TipoContatos.Find(id);
            if (ContatoBuscado != null)
            {
                _Connect.TipoContatos.Remove(ContatoBuscado);
                _Connect.SaveChanges();
            }
        }

        List<TipoContato> ITipoContatoRepository.Listar()
        {
            return _Connect.TipoContatos
               .ToList();
        }

        Contato ITipoContatoRepository.BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
