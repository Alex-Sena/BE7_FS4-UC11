using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class ChapterContext: DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options): base(options)
        {
        }
        //vamos utilizar esse metodo para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-NHJ4IH5\\SQLEXPRESS; initisl catalog = Chapter; Integrated Security = true");
            }
        }

        //dbset representa as entidades que serão utilizadas nas operções de leitura, criação, atualização e exclusão
        public DbSet<Livro> Livros { get; set; }
    }
}
