namespace MiniBitcoin.Console;

public class Carteira
{
    public decimal SaldoBrl { get; private set; }

    public decimal SaldoBitcoin { get; private set; }

    public Carteira(decimal saldoBrlInicial, decimal saldoBitcoinInicial)
    {
        if (saldoBrlInicial < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(saldoBrlInicial),
                "O saldo em reais não pode ser negativo.");
        }

        if (saldoBitcoinInicial < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(saldoBitcoinInicial),
                "O saldo em Bitcoin não pode ser negativo.");
        }

        SaldoBrl = saldoBrlInicial;
        SaldoBitcoin = saldoBitcoinInicial;
    }

    public void DebitarBrl(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(valor),
                "O valor do débito deve ser maior que zero.");
        }

        if (valor > SaldoBrl)
        {
            throw new InvalidOperationException(
                "Saldo em reais insuficiente.");
        }

        SaldoBrl -= valor;
    }

    public void DebitarBitcoin(decimal quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantidade),
                "A quantidade deve ser maior que zero.");
        }

        if (quantidade > SaldoBitcoin)
        {
            throw new InvalidOperationException(
                "Saldo em Bitcoin insuficiente.");
        }

        SaldoBitcoin -= quantidade;
    }
}