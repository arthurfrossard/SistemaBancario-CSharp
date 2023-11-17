using Tarifas;

namespace Contas;

public class ContaInternacional : Conta, ITarifa
{
    private double TaxaCambio { get; }

    public ContaInternacional(double saldoEmDolares, double taxaCambio) : base(saldoEmDolares)
      => base.SaldoAtualEmReais = saldoEmDolares * taxaCambio;

    public virtual double Calcular()
      => SaldoAtualEmReais * 0.025;

}

