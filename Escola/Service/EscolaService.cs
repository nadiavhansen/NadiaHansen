using Escola.Entidades;
using Escola.Infra;
using Escola.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Service
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _bancoDeDados;

        public EscolaService(IEscolaRepository bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public bool SalvarGabarito(Gabarito gabarito)
        {
            return _bancoDeDados.SalvarGabarito(gabarito);
        }

        public bool SalvarAluno(CartaoRepsotaAluno cartaoResposta)
        {
            return _bancoDeDados.SalvarCartaoResposta(cartaoResposta);
        }

        public AlunoViewModel RetonarMedia(int matricula)
        {
            List<CartaoRepsotaAluno> cartoesRespostaAluno = _bancoDeDados.BuscarCartoesAluno(matricula).ToList();
           
            List<int> notas = new List<int>();
            
            foreach (var cartaoResposta in cartoesRespostaAluno)
            {
                Gabarito gabarito = _bancoDeDados.BuscarGabarito(cartaoResposta.CodigoProva);
                int nota = 0;

                foreach (var questaoAluno in cartaoResposta.Questoes)
                {
                    QuestaoGabarito gabaritoQuestao = gabarito.Questoes.First(x => x.CodigoQuestao == questaoAluno.CodigoQuestao);

                    if (gabaritoQuestao.Resposta == questaoAluno.Resposta)
                    {
                        nota += gabaritoQuestao.Peso;
                    }
                }
                notas.Add(nota);
            }
            int media = Calculos.CalcularMedia(notas);

            AlunoViewModel aluno = new AlunoViewModel() { 
                Matricula = cartoesRespostaAluno.First().Matricula,
                Nome = cartoesRespostaAluno.First().Nome,
                Nota = media,
                Situacao = Calculos.Situacao(media)
            };

            return aluno;
        }
        
        public List<AlunoViewModel> BuscarAlunosAprovados()
        {
            IEnumerable<int> alunos = _bancoDeDados.BuscarTodosAlunos().Select(x => x.Matricula).Distinct();
            List<AlunoViewModel> alunosAprovados = new List<AlunoViewModel>();

            foreach (var aluno in alunos)
            {
                AlunoViewModel situacaoAluno = RetonarMedia(aluno);

                if(situacaoAluno.Situacao == "Aprovado")
                {
                    alunosAprovados.Add(situacaoAluno);
                }
            }

            return alunosAprovados;
        }
    }
}
