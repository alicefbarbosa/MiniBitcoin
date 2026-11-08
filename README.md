# ₿ MiniBitcoin

Aplicação de console desenvolvida em C# e .NET 10 para simulação de operações de compra e venda de Bitcoin, utilizando testes automatizados com xUnit e a metodologia TDD (Test-Driven Development).

## Funcionalidades

- Gerenciamento de carteira com saldos em BRL e Bitcoin.
- Consulta de cotação simulada do Bitcoin.
- Compra e venda de Bitcoin.
- Validação de saldo disponível.
- Histórico de transações.
- Cálculo do patrimônio total em reais.
- Menu interativo via terminal.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub
- TDD (Test-Driven Development)

## Estrutura do projeto

```text
MiniBitcoin/
├── MiniBitcoin.Console/
│   ├── Carteira.cs
│   ├── Transacao.cs
│   ├── Extrato.cs
│   ├── ServicoTransacao.cs
│   └── Program.cs
│
├── MiniBitcoin.Tests/
│   ├── CarteiraTests.cs
│   ├── TransacaoTests.cs
│   ├── ExtratoTests.cs
│   └── ...
│
├── MiniBitcoin.sln
└── README.md
```

## Como executar

Clone o repositório:

```bash
git clone URL_DO_REPOSITORIO
```

Acesse a pasta:

```bash
cd MiniBitcoin
```

Execute a aplicação:

```bash
dotnet run --project MiniBitcoin.Console/MiniBitcoin.Console.csproj
```

## Como executar os testes

```bash
dotnet test
```

## Observação

A cotação do Bitcoin utilizada na aplicação é simulada, não representando necessariamente o valor real de mercado.

## Autora
Alice Fernandes Barbosa - 326128348
Desenvolvido como atividade acadêmica da disciplina de Gestão e Qualidade de Software.
