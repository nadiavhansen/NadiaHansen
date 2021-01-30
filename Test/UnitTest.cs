using Escola.Service;
using System.Collections.Generic;
using Xunit;

namespace Escola.Test
{
    public class UnitTest
    {
        [Fact]
        public void Deve_Retornar_A_Media_Correta()
        {
            //Arrange
            var notas = new List<int>() { 10, 10, 10, 10 };

            //Act
            int resultado = Calculos.CalcularMedia(notas);

            //Assert
            Assert.Equal(10, resultado);
        }

        [Theory]
        [InlineData(10, "Aprovado")]
        [InlineData(5, "Reprovado")]
        public void Deve_Retornar_A_Situacao_Correta(int nota, string resultadoEsperado)
        {
            //Act
            string resultado = Calculos.Situacao(nota);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
