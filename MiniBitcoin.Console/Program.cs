using MiniBitcoin.Console;
using System.Globalization;

// Configurações iniciais
var carteira = new Carteira(1000m, 0.01m);
var servico = new ServicoTransacao();

const decimal cotacaoBitcoin = 100000m;

bool executando = true;

while (executando)
{
    System.Console.Clear();

    System.Console.WriteLine("================================");
    System.Console.WriteLine("       MINI BITCOIN");
    System.Console.WriteLine("================================");
    System.Console.WriteLine("1 - Consultar cotação");
    System.Console.WriteLine("2 - Consultar saldos");
    System.Console.WriteLine("3 - Comprar Bitcoin");
    System.Console.WriteLine("4 - Vender Bitcoin");
    System.Console.WriteLine("5 - Consultar extrato");
    System.Console.WriteLine("0 - Sair");
    System.Console.WriteLine("================================");
    System.Console.Write("Escolha uma opção: ");

    string? opcao = System.Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                System.Console.WriteLine(
                    $"\nCotação atual do Bitcoin: R$ {cotacaoBitcoin:N2}");
                break;

            case "2":
                System.Console.WriteLine("\n======= SALDOS =======");
                System.Console.WriteLine(
                    $"Saldo em BRL: R$ {carteira.SaldoBrl:N2}");
                System.Console.WriteLine(
                    $"Saldo em BTC: {carteira.SaldoBitcoin:N8}");
                System.Console.WriteLine(
                    $"Patrimônio total: R$ {servico.Extrato.CalcularPatrimonioTotal(carteira, cotacaoBitcoin):N2}");
                break;

            case "3":
                System.Console.Write("\nDigite o valor em reais para comprar Bitcoin: R$ ");

                if (LerValor(out decimal valorCompra))
                {
                    servico.ComprarBitcoin(
                        carteira,
                        valorCompra,
                        cotacaoBitcoin
                    );

                    System.Console.WriteLine("\nCompra realizada com sucesso!");
                }
                break;

            case "4":
                System.Console.Write("\nDigite a quantidade de Bitcoin para vender: ");

                if (LerValor(out decimal quantidadeVenda))
                {
                    servico.VenderBitcoin(
                        carteira,
                        quantidadeVenda,
                        cotacaoBitcoin
                    );

                    System.Console.WriteLine("\nVenda realizada com sucesso!");
                }
                break;

            case "5":
                System.Console.WriteLine("\n======= EXTRATO =======");

                if (servico.Extrato.Transacoes.Count == 0)
                {
                    System.Console.WriteLine("Nenhuma transação realizada.");
                }
                else
                {
                    foreach (var transacao in servico.Extrato.Transacoes)
                    {
                        System.Console.WriteLine("--------------------------------");
                        System.Console.WriteLine($"Tipo: {transacao.Tipo}");
                        System.Console.WriteLine($"Data: {transacao.Data}");
                        System.Console.WriteLine($"Quantidade BTC: {transacao.QuantidadeBitcoin:N8}");
                        System.Console.WriteLine($"Valor: R$ {transacao.ValorBrl:N2}");
                        System.Console.WriteLine($"Cotação: R$ {transacao.Cotacao:N2}");
                    }

                    System.Console.WriteLine("--------------------------------");
                    System.Console.WriteLine(
                        $"Patrimônio total: R$ {servico.Extrato.CalcularPatrimonioTotal(carteira, cotacaoBitcoin):N2}");
                }
                break;

            case "0":
                executando = false;
                System.Console.WriteLine("\nEncerrando MiniBitcoin. Até mais!");
                break;

            default:
                System.Console.WriteLine("\nOpção inválida!");
                break;
        }
    }
    catch (Exception ex)
    {
        System.Console.WriteLine($"\nErro: {ex.Message}");
    }

    if (executando)
    {
        System.Console.WriteLine("\nPressione ENTER para continuar...");
        System.Console.ReadLine();
    }
}

bool LerValor(out decimal valor)
{
    string? entrada = System.Console.ReadLine();

    bool valido = decimal.TryParse(
        entrada?.Replace(',', '.'),
        NumberStyles.Number,
        CultureInfo.InvariantCulture,
        out valor
    );

    if (!valido || valor <= 0)
    {
        System.Console.WriteLine("Valor inválido! Digite um número positivo.");
        return false;
    }

    return true;
}