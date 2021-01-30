using System.Collections.Generic;

namespace Escola.Entidades
{
    public class CartaoRepsotaAluno
    {
        public int CodigoCartaoResposta { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int CodigoProva { get; set; }
        public List<Questao> Questoes { get; set; }

        public class Questao
        {
            public int CodigoAluno { get; set; }
            public int CodigoQuestao { get; set; }
            public string Resposta { get; set; }
        }
    }
}
