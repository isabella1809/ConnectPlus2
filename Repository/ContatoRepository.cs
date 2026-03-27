
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Repository;

using ConnectPlus.BdContexConnect;
using Microsoft.EntityFrameworkCore;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _connect;

    public ContatoRepository(ConnectContext connect)
    {
        _connect = connect;
    }
    /// <summary>
    /// Atualizar um tipo de contato 
    /// </summary>
    /// <param name="id">Id do contato a ser atualizado</param>
    /// <param name="contato">Novos dados dos contatos</param>
    public void Atualizar(Guid id, Contato contato)
    {
        var ContatoBuscado = _connect.Contatos.Find(id);
        if (ContatoBuscado != null)
        {
          ContatoBuscado.Nome=contato.Nome;
            ContatoBuscado.Numero = contato.Numero;

            _connect.SaveChanges();

        }
    }
    /// <summary>
    /// busca um contato por id 
    /// </summary>
    /// <param name="id">id do contato a ser buscado</param>
    /// <returns>Objeto do Contato com as informações do contato buscado</returns>
    public Contato BuscarPorId(Guid id)
    {
        return _connect.Contatos.Find(id);
    }
    /// <summary>
    /// cadastra um novo contato
    /// </summary>
    /// <param name="contato">contato a ser cadastrado</param>]
    public void Cadastra(Contato novocontato)
    {
        _connect.Contatos.Add(novocontato);
        _connect.SaveChanges();
    }

    public void Cadastra(TipoContato novoTipoContato)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// deletar um contato
    /// </summary>
    /// <param name="id">id do cotato a ser deletado</param>
    public void Deletar(Guid id)
    {
        var ContatoBuscado = _connect.Contatos.Find(id);
        if (ContatoBuscado != null)
        {
            _connect.Contatos.Remove(ContatoBuscado);
            _connect.SaveChanges();
        }
    }
    /// <summary>
    /// buscar a lista do contato cadastrados 
    /// </summary>
    /// <returns>uma lista de Contato</returns>
    public List<Contato> Listar()
    {
        return _connect.Contatos
               .OrderBy(Contato => Contato.Nome)
               .OrderBy(Contato => Contato.Numero)
               .ToList();
    }


}
