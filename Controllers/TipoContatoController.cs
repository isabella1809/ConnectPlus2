
using Azure.AI.ContentSafety;
using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using ConnectPlus.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoContatoController : ControllerBase
    {
      
       

        public TipoContatoController(ContentSafetyClient contentSafetyClient, IContatoRepository contatoRepository)
        {
            _contentSafetyClient = contentSafetyClient;
            _TipocontatoRepository = contatoRepository;
        }
        private static List<tipoContato> lista = new List<tipoContato>();
        private object _tipoContatoRepository;
        private object novotipoContato;
        private ContentSafetyClient _contentSafetyClient;
        private IContatoRepository _TipocontatoRepository;
        private object novotipocontato;

        [HttpPost]
        public IActionResult Cadastrar(ContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new tipoContato
                {
                    Nome = tipoContato.Nome!,
                    SMS = tipoContato.SMS!, 
                    Email = tipoContato.Email!
                };

                _tipoContatoRepository.Cadastra(novoTipoContato);

                return StatusCode(201, novoTipoContato);
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
        public IActionResult Buscar(int id)
        {
            var tipo = lista.FirstOrDefault(t => t.Id == id);

            if (tipo == null)
                return NotFound("Tipo de contato não encontrado");

            return Ok(tipo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, tipoContato tipoAtualizado)
        {
            var tipo = lista.FirstOrDefault(t => t.Id == id);

            if (tipo == null)
                return NotFound("Tipo de contato não encontrado");

            tipo.Nome = tipoAtualizado.Nome;

            return Ok(tipo);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tipo = lista.FirstOrDefault(t => t.Id == id);

            if (tipo == null)
                return NotFound("Tipo de contato não encontrado");

            lista.Remove(tipo);

            return Ok("Deletado com sucesso");
        }
    }
}