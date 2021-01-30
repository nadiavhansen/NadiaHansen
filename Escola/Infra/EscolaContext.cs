using Escola.Entidades;
using Microsoft.EntityFrameworkCore;
using static Escola.Entidades.CartaoRepsotaAluno;

namespace Escola.Infra
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Gabarito> Gabaritos { get; set; }
        public DbSet<QuestaoGabarito> QuestoesGabarito { get; set; }
        public DbSet<CartaoRepsotaAluno> Alunos{ get; set; }
        public DbSet<Questao> Questoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gabarito>().HasKey(x => x.Codigo);
            modelBuilder.Entity<Gabarito>().HasMany(x => x.Questoes);
            modelBuilder.Entity<QuestaoGabarito>().HasKey(x => new { x.CodigoGabarito, x.CodigoQuestao });

            modelBuilder.Entity<CartaoRepsotaAluno>().HasKey(x => x.CodigoCartaoResposta);
            modelBuilder.Entity<CartaoRepsotaAluno>().HasMany(x => x.Questoes);
            modelBuilder.Entity<Questao>().HasKey(x => new { x.CodigoAluno, x.CodigoQuestao }); 
        }
    }
}
