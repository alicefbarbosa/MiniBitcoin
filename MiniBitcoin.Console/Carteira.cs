namespace MiniBitcoin.Console;

public class Carteira
{
    public decimal SaldoBrl { get; private set; }
    public decimal SaldoBitcoin { get; private set; }

    public Carteira(decimal saldoBrl, decimal saldoBitcoin)
    {
        if (saldoBrl < 0)
            throw new ArgumentOutOfRangeException(nameof(saldoBrl));

        if (saldoBitcoin < 0)
            throw new ArgumentOutOfRangeException(nameof(saldoBitcoin));

        SaldoBrl = saldoBrl;
        SaldoBitcoin = saldoBitcoin;
    }

    public void DebitarBrl(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentOutOfRangeException(nameof(valor));

        if (valor > SaldoBrl)
            throw new InvalidOperationException("Saldo em reais insuficiente.");

        SaldoBrl -= valor;
    }

    public void DebitarBitcoin(decimal quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade));

        if (quantidade > SaldoBitcoin)
            throw new InvalidOperationException("Saldo em Bitcoin insuficiente.");

        SaldoBitcoin -= quantidade;
    }

    public void CreditarBrl(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentOutOfRangeException(nameof(valor));

        SaldoBrl += valor;
    }

    public void CreditarBitcoin(decimal quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade));

        SaldoBitcoin += quantidade;
    }
}