/* Controller Responsável por fazer o CRUD dos dados na tabela Contato do Banco de Dados Agenda*/

using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        // Atributo somente leitura
        private readonly AgendaContext _context;

        // O Construtor recebendo como parâmetro o Context Agenda
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        // Endpoint para fazer o post das informações, inseri-las na tabela Contatos
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();

            // Retorna qual a rota para obter o registro que acabou de ser criado
            return CreatedAtAction(nameof(FindContactId), new { id = contato.Id }, contato);
        }

        // Endpoint para inserir o id do contato da tabela Contatos e fazer uma busca retornando os dados
        [HttpGet("{id}")]
        public IActionResult FindContactId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        // Fazendo busca por nome ou por um charactere que corresponde ao nome.
        [HttpGet("ObterPorNome")]
        public IActionResult FindName(string name)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(name));
            return Ok(contatos);
        }

        // Endpoint para Atualizar os dados do contato, através de uma busca por id
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        // Endpoint para deletar da abela os dados de um contato passado por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
