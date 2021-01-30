using Escola.Entidades;
using Escola.ViewModel;
using System.Collections.Generic;

namespace Escola.Service
{
    public interface IEscolaService
    {
        bool SalvarGabarito(Gabarito gabarito);
        bool SalvarAluno(CartaoRepsotaAluno aluno);
        AlunoViewModel RetonarMedia(int codigoAluno);
        List<AlunoViewModel> BuscarAlunosAprovados();
    }
}
