using Azure.AI.ContentSafety;
using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;
    private readonly IContatoRepository _contatoRepository;
    private static List<Contato> lista = new List<Contato>();
    private TipoEvento novocontato;

    public ContatoController(ContentSafetyClient contentSafetyClient, IContatoRepository contatoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _contatoRepository = contatoRepository;
    }
    //  CADASTRAR
    [HttpPost]
    public IActionResult Cadastrar(ContatoDTO tipoContato)
    {
        try
        {
            var TipoContato = new TipoContato
            {
                Nome = tipoContato.Nome!,
                Numero = tipoContato.Numero!
            };

            _contatoRepository.Cadastra(TipoContato);

            return StatusCode(201, TipoContato);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
  
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, [FromForm] Contato contatoAtualizado, IFormFile imagem)
    {
        var contato = lista.FirstOrDefault(c => c.IdContato == id);

        if (contato == null)
            return NotFound("Contato não encontrado");

        contato.Nome = contatoAtualizado.Nome;
        contato.FormaContato = contatoAtualizado.FormaContato;
        contato.IdTipoContato = contatoAtualizado.IdTipoContatoNavigation;

        if (imagem != null)
        {
            var pasta = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!string.IsNullOrEmpty(contato.Imagem))
            {
                var caminhoAntigo = Path.Combine(pasta, contato.Imagem);

                if (System.IO.File.Exists(caminhoAntigo))
                {
                    System.IO.File.Delete(caminhoAntigo);
                }
            }

            var nomeArquivo = Guid.NewGuid() + Path.GetExtension(imagem.FileName);
            var caminho = Path.Combine(pasta, nomeArquivo);

            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                imagem.CopyTo(stream);
            }

            contato.Imagem = nomeArquivo;
        }

        return Ok(contato);
    }

    [HttpDelete("{id}")]
       public IActionResult Deletar(Guid id)
    {
        var contato = lista.FirstOrDefault(c => c.IdContato == id);

        if (contato == null)
            return NotFound("Contato não encontrado");

        var pasta = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        if (!string.IsNullOrEmpty(contato.Imagem))
        {
            var caminho = Path.Combine(pasta, contato.Imagem);

            if (System.IO.File.Exists(caminho))
            {
                System.IO.File.Delete(caminho);
            }
        }

        lista.Remove(contato);

        return Ok("Contato deletado com sucesso");
    }
    }

