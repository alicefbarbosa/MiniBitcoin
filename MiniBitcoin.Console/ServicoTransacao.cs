namespace MiniBitcoin.Console;

public class ServicoTransacao
{
    public Extrato Extrato { get; } = new();

    public void ComprarBitcoin(
        Carteira carteira,
        decimal valorBrl,
        decimal cotacao)
    {
        if (valorBrl <= 0)
            throw new ArgumentOutOfRangeException(nameof(valorBrl));

        if (cotacao <= 0)
            throw new ArgumentOutOfRangeException(nameof(cotacao));

        decimal quantidadeBitcoin = valorBrl / cotacao;

        carteira.DebitarBrl(valorBrl);
        carteira.CreditarBitcoin(quantidadeBitcoin);

        Extrato.RegistrarCompra(
            quantidadeBitcoin,
            valorBrl,
            cotacao
        );
    }

    public void VenderBitcoin(
        Carteira carteira,
        decimal quantidadeBitcoin,
        decimal cotacao)
    {
        if (quantidadeBitcoin <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidadeBitcoin));

        if (cotacao <= 0)
            throw new ArgumentOutOfRangeException(nameof(cotacao));

        decimal valorBrl = quantidadeBitcoin * cotacao;

        carteira.DebitarBitcoin(quantidadeBitcoin);
        carteira.CreditarBrl(valorBrl);

        Extrato.RegistrarVenda(
            quantidadeBitcoin,
            valorBrl,
            cotacao
        );
    }
}