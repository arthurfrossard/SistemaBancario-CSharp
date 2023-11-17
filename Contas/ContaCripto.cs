namespace Contas;

public class ContaCripto : Conta
{
    private double TaxaCambio { get; }

    public ContaCripto(double saldoEmDolares, double taxaCambio) : base(saldoEmDolares)
      => base.SaldoAtualEmReais = saldoEmDolares * taxaCambio;

}

