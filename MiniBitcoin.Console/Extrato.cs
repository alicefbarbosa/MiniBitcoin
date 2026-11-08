namespace MiniBitcoin.Console;

public class Extrato
{
    private readonly List<Transacao> _transacoes = new();

    public IReadOnlyList<Transacao> Transacoes => _transacoes;

    public void RegistrarCompra(
        decimal quantidadeBitcoin,
        decimal valorBrl,
        decimal cotacao)
    {
        ValidarTransacao(quantidadeBitcoin, valorBrl, cotacao);

        var transacao = new Transacao(
            "Compra",
            quantidadeBitcoin,
            valorBrl,
            cotacao
        );

        _transacoes.Add(transacao);
    }

    public void RegistrarVenda(
        decimal quantidadeBitcoin,
        decimal valorBrl,
        decimal cotacao)
    {
        ValidarTransacao(quantidadeBitcoin, valorBrl, cotacao);

        var transacao = new Transacao(
            "Venda",
            quantidadeBitcoin,
            valorBrl,
            cotacao
        );

        _transacoes.Add(transacao);
    }

    public decimal CalcularPatrimonioTotal(
        Carteira carteira,
        decimal cotacao)
    {
        if (cotacao <= 0)
            throw new ArgumentOutOfRangeException(nameof(cotacao));

        return carteira.SaldoBrl +
               (carteira.SaldoBitcoin * cotacao);
    }

    private void ValidarTransacao(
        decimal quantidadeBitcoin,
        decimal valorBrl,
        decimal cotacao)
    {
        if (quantidadeBitcoin <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidadeBitcoin));

        if (valorBrl <= 0)
            throw new ArgumentOutOfRangeException(nameof(valorBrl));

        if (cotacao <= 0)
            throw new ArgumentOutOfRangeException(nameof(cotacao));
    }
}