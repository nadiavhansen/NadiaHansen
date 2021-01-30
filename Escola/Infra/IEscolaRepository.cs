using Escola.Entidades;
using System.Collections.Generic;

namespace Escola.Infra
{
    public interface IEscolaRepository
    {
        bool SalvarGabarito(Gabarito gabarito);
        bool SalvarCartaoResposta(CartaoRepsotaAluno cartaoRespostaAluno);
        Gabarito BuscarGabarito(int codigoGabarito);
        List<CartaoRepsotaAluno> BuscarCartoesAluno(int matricula);
        List<CartaoRepsotaAluno> BuscarTodosAlunos();
    }
}
