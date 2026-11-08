using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class ExtratoTests
{
    [Fact]
    public void DeveRegistrarCompraNoHistorico()
    {
        // Arrange
        var extrato = new Extrato();

        // Act
        extrato.RegistrarCompra(0.005m, 500m, 100000m);

        // Assert
        Assert.Single(extrato.Transacoes);
        Assert.Equal("Compra", extrato.Transacoes[0].Tipo);
        Assert.Equal(0.005m, extrato.Transacoes[0].QuantidadeBitcoin);
        Assert.Equal(500m, extrato.Transacoes[0].ValorBrl);
    }

    [Fact]
    public void DeveRegistrarVendaNoHistorico()
    {
        // Arrange
        var extrato = new Extrato();

        // Act
        extrato.RegistrarVenda(0.005m, 500m, 100000m);

        // Assert
        Assert.Single(extrato.Transacoes);
        Assert.Equal("Venda", extrato.Transacoes[0].Tipo);
    }

    [Fact]
    public void DeveCalcularPatrimonioTotalDaCarteira()
    {
        // Arrange
        var carteira = new Carteira(500m, 0.005m);
        var extrato = new Extrato();

        // Act
        decimal patrimonio = extrato.CalcularPatrimonioTotal(carteira, 100000m);

        // Assert
        Assert.Equal(1000m, patrimonio);
    }

    [Fact]
    public void NaoDeveCalcularPatrimonioComCotacaoInvalida()
    {
        // Arrange
        var carteira = new Carteira(500m, 0.005m);
        var extrato = new Extrato();

        // Act e Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            extrato.CalcularPatrimonioTotal(carteira, 0m);
        });
    }

    [Fact]
    public void DeveManterHistoricoDeMultiplasTransacoes()
    {
        // Arrange
        var extrato = new Extrato();

        // Act
        extrato.RegistrarCompra(0.005m, 500m, 100000m);
        extrato.RegistrarVenda(0.002m, 200m, 100000m);

        // Assert
        Assert.Equal(2, extrato.Transacoes.Count);
    }
}