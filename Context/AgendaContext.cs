/* O Context é responsável em fazer a comunicação com o banco de dados. AgendaContext
 representa o nome do banco de dados que será criado, com o nome Agenda.*/

using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Context
{
    public class AgendaContext : DbContext
    {
        /* O Construtor que vai receber a conexão com o banco de dados e vai enviar
         para o base (construtor) da classe pai que é o DbContext*/
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }
        /* Propriedade que irá referenciar a entidade Contato, ou seja, a classe
         que será criada uma tabela no banco de dados com as suas propriedades. 
        Essa tabela se chamará Contatos*/
        public DbSet<Contato> Contatos { get; set; }
    }
}
