using Escola.Entidades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Infra.Repositorio
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly IServiceScope _scope;
        private readonly EscolaContext _escolaContext;

        public EscolaRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _escolaContext = _scope.ServiceProvider.GetRequiredService<EscolaContext>();
        }

        public bool SalvarGabarito(Gabarito gabarito)
        {
            _escolaContext.Gabaritos.Add(gabarito);

            int numeroDeIntensCriados = _escolaContext.SaveChanges();

            if (numeroDeIntensCriados >= 1)
                return true;

            return false;
        }

        public bool SalvarCartaoResposta(CartaoRepsotaAluno cartaoRespostaAluno)
        {
            var matriculaAlunosBanco = _escolaContext.Alunos.Select(x => x.Matricula).Distinct();

            if (!matriculaAlunosBanco.Contains(cartaoRespostaAluno.Matricula) && matriculaAlunosBanco.Count() >= 1)
                return false;
            
            _escolaContext.Alunos.Add(cartaoRespostaAluno);
            int numeroDeIntensCriados = _escolaContext.SaveChanges();
            if (numeroDeIntensCriados >= 1)
                return true;

            return false;
        }

        public List<CartaoRepsotaAluno> BuscarCartoesAluno(int matricula)
        {
            List<CartaoRepsotaAluno> cartoesAluno = _escolaContext.Alunos.Where(x => x.Matricula == matricula).ToList();
            return cartoesAluno;
        }

        public Gabarito BuscarGabarito(int codigoGabarito)
        {
            Gabarito gabarito = _escolaContext.Gabaritos.Find(codigoGabarito);
            return gabarito;
        }

        public List<CartaoRepsotaAluno> BuscarTodosAlunos()
        {
            List<CartaoRepsotaAluno> cartoesAluno = _escolaContext.Alunos.ToList();
            return cartoesAluno;
        }
    }
}
