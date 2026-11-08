using MiniBitcoin.Console;

namespace MiniBitcoin.Tests;

public class TransacaoTests
{
    [Fact]
    public void DeveComprarBitcoinComSaldoBrlDisponivel()
    {
        var carteira = new Carteira(1000m, 0m);
        var transacao = new ServicoTransacao();

        transacao.ComprarBitcoin(carteira, 500m, 100000m);

        Assert.Equal(500m, carteira.SaldoBrl);
        Assert.Equal(0.005m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveComprarBitcoinComSaldoBrlInsuficiente()
    {
        var carteira = new Carteira(100m, 0m);
        var transacao = new ServicoTransacao();

        Assert.Throws<InvalidOperationException>(() =>
        {
            transacao.ComprarBitcoin(carteira, 200m, 100000m);
        });

        Assert.Equal(100m, carteira.SaldoBrl);
        Assert.Equal(0m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveComprarBitcoinComValorOuCotacaoInvalida()
    {
        var carteira = new Carteira(1000m, 0m);
        var transacao = new ServicoTransacao();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            transacao.ComprarBitcoin(carteira, 0m, 100000m);
        });

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            transacao.ComprarBitcoin(carteira, 100m, 0m);
        });
    }

    [Fact]
    public void DeveVenderBitcoinComSaldoDisponivel()
    {
        var carteira = new Carteira(0m, 0.01m);
        var transacao = new ServicoTransacao();

        transacao.VenderBitcoin(carteira, 0.005m, 100000m);

        Assert.Equal(500m, carteira.SaldoBrl);
        Assert.Equal(0.005m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveVenderBitcoinComSaldoInsuficiente()
    {
        var carteira = new Carteira(0m, 0.001m);
        var transacao = new ServicoTransacao();

        Assert.Throws<InvalidOperationException>(() =>
        {
            transacao.VenderBitcoin(carteira, 0.01m, 100000m);
        });

        Assert.Equal(0m, carteira.SaldoBrl);
        Assert.Equal(0.001m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void NaoDeveVenderBitcoinComQuantidadeOuCotacaoInvalida()
    {
        var carteira = new Carteira(0m, 0.01m);
        var transacao = new ServicoTransacao();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            transacao.VenderBitcoin(carteira, 0m, 100000m);
        });

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            transacao.VenderBitcoin(carteira, 0.001m, 0m);
        });
    }
}