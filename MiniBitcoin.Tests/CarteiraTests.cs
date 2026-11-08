using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class CarteiraTests
{
    [Fact]
    public void DeveCriarCarteiraComSaldosIniciaisValidos()
    {
        // Arrange
        decimal saldoBrl = 1000m;
        decimal saldoBitcoin = 0.01m;

        // Act
        var carteira = new Carteira(saldoBrl, saldoBitcoin);

        // Assert
        Assert.Equal(saldoBrl, carteira.SaldoBrl);
        Assert.Equal(saldoBitcoin, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveCriarCarteiraComSaldoBrlNegativo()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Carteira(-100m, 0.01m));
    }

    [Fact]
    public void NaoDeveCriarCarteiraComSaldoBitcoinNegativo()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Carteira(1000m, -0.01m));
    }

    [Fact]
    public void DeveDebitarValorValidoDoSaldoBrl()
    {
        // Arrange
        var carteira = new Carteira(1000m, 0.01m);

        // Act
        carteira.DebitarBrl(200m);

        // Assert
        Assert.Equal(800m, carteira.SaldoBrl);
    }

    [Fact]
    public void NaoDeveDebitarValorMaiorQueSaldoBrl()
    {
        var carteira = new Carteira(100m, 0.01m);

        Assert.Throws<InvalidOperationException>(() =>
            carteira.DebitarBrl(200m));
    }

    [Fact]
    public void NaoDeveDebitarValorNegativoOuZeroDoSaldoBrl()
    {
        var carteira = new Carteira(1000m, 0.01m);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            carteira.DebitarBrl(-50m));

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            carteira.DebitarBrl(0m));
    }

    [Fact]
    public void DeveDebitarQuantidadeValidaDeBitcoin()
    {
        // Arrange
        var carteira = new Carteira(1000m, 0.01m);

        // Act
        carteira.DebitarBitcoin(0.005m);

        // Assert
        Assert.Equal(0.005m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveDebitarQuantidadeMaiorQueSaldoBitcoin()
    {
        var carteira = new Carteira(1000m, 0.01m);

        Assert.Throws<InvalidOperationException>(() =>
            carteira.DebitarBitcoin(0.02m));
    }

    [Fact]
    public void NaoDeveDebitarQuantidadeNegativaOuZeroDeBitcoin()
    {
        var carteira = new Carteira(1000m, 0.01m);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            carteira.DebitarBitcoin(-0.001m));

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            carteira.DebitarBitcoin(0m));
    }
}