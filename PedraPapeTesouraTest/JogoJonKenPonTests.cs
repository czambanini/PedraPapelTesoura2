using FluentAssertions;
using PedraPapelTesoura;
using System.Runtime.Intrinsics.X86;

namespace PedraPapeTesouraTest
{
    /*
     A cada rodada, a forma jogada por cada jogador é verificada e o programa determina um vencedor ou empate.

    [x] Pedra quebra tesoura;
    [x] Tesoura corta papel;
    [x] Papel cobre pedra;
    [x] O jogo empata se ambos os jogadores usarem a mesma forma.

     */

    public class JogoJonKenPonTests
    {
        JogoService sut;
        public JogoJonKenPonTests()
        {
            sut = new JogoService();
        }

        [Fact]
        public void Jogo_deve_empatar_caso_ambos_os_jogadores_usem_a_mesma_forma()
        {
            // Arrange
            var forma1 = Forma.Pedra;
            var forma2 = Forma.Pedra;

            // Act
            var resultado = sut.Jogar(forma1, forma2);

            // Assert
            resultado.Should().BeNull();
        }

        [Theory]
        [InlineData(Forma.Pedra, Forma.Tesoura, Forma.Pedra, "Pedra quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Pedra, Forma.Pedra, "Pedra quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Papel, Forma.Tesoura, "Tesoura corta papel")]
        [InlineData(Forma.Papel, Forma.Tesoura, Forma.Tesoura, "Tesoura corta papel")]
        [InlineData(Forma.Papel, Forma.Pedra, Forma.Papel, "Papel cobre pedra")]
        [InlineData(Forma.Pedra, Forma.Papel, Forma.Papel, "Papel cobre pedra")]
        [InlineData(Forma.Pedra, Forma.Lagarto, Forma.Pedra, "Pedra esmaga lagarto")]
        [InlineData(Forma.Lagarto, Forma.Pedra, Forma.Pedra, "Pedra esmaga lagarto")]
        [InlineData(Forma.Lagarto, Forma.Spock, Forma.Lagarto, "Lagarto envenena Spock")]
        [InlineData(Forma.Spock, Forma.Lagarto, Forma.Lagarto, "Lagarto envenena Spock")]
        [InlineData(Forma.Spock, Forma.Tesoura, Forma.Spock, "Spock quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Spock, Forma.Spock, "Spock quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Lagarto, Forma.Tesoura, "Tesoura decapta lagarto")]
        [InlineData(Forma.Lagarto, Forma.Tesoura, Forma.Tesoura, "Tesoura decapta lagarto")]
        [InlineData(Forma.Lagarto, Forma.Papel, Forma.Lagarto, "Lagarto come papel")]
        [InlineData(Forma.Papel, Forma.Lagarto, Forma.Lagarto, "Lagarto come papel")]
        [InlineData(Forma.Papel, Forma.Spock, Forma.Papel, "Papel contesta Spock")]
        [InlineData(Forma.Spock, Forma.Papel, Forma.Papel, "Papel contesta Spock")]
        [InlineData(Forma.Spock, Forma.Pedra, Forma.Spock, "Spock vaporiza pedra")]
        [InlineData(Forma.Pedra, Forma.Spock, Forma.Spock, "Spock vaporiza pedra")]
        public void Resultado_jogo_deve_ser_conforme_esperado(Forma forma1, Forma forma2, Forma resultadoEsperado, string requisito)
        {
            // Arrange / Act
            var resultado = sut.Jogar(forma1, forma2);

            // Assert
            resultado.Should().Be(resultadoEsperado, requisito);
        }

        [Fact]
        public void Tentativa_de_jogar_com_formas_inválidas_deve_resultar_em_exception()
        {
            // Arrange 
            var forma1 = "Pedra";
            var forma2 = "Paspel";

            // Act // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Jogar(forma1, forma2));
        }
    }
}