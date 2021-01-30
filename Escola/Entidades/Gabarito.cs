using System.Collections.Generic;

namespace Escola.Entidades
{
    public class Gabarito
    {
      public int Codigo { get; set; }
      public List<QuestaoGabarito> Questoes { get; set; }
    }
    public class QuestaoGabarito
    {
        public int CodigoQuestao { get; set; }
        public string Resposta { get; set; }
        public int Peso { get; set; }
        public int CodigoGabarito { get; set; }
    }
}
