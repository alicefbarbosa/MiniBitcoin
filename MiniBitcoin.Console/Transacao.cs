namespace MiniBitcoin.Console;

public class Transacao
{
    public string Tipo { get; private set; }
    public decimal QuantidadeBitcoin { get; private set; }
    public decimal ValorBrl { get; private set; }
    public decimal Cotacao { get; private set; }
    public DateTime Data { get; private set; }

    public Transacao(
        string tipo,
        decimal quantidadeBitcoin,
        decimal valorBrl,
        decimal cotacao)
    {
        Tipo = tipo;
        QuantidadeBitcoin = quantidadeBitcoin;
        ValorBrl = valorBrl;
        Cotacao = cotacao;
        Data = DateTime.Now;
    }
}