using System.Collections.Generic;
using System.Linq;

namespace Escola.Service
{
    public static class Calculos
    {
        public static int CalcularMedia(List<int> notas)
        {
            var notasTotais = notas.Sum();
            var quantidadeDeNotas = notas.Count;
            var media = notasTotais / quantidadeDeNotas;

            return media;
        }

        public static string Situacao(int nota)
        {
            if (nota >= 7)
                return "Aprovado";

            return "Reprovado";
        }
    }
}
