using Tarifas;

namespace Contas;

public class ContaCorrente : Conta, ITarifa
{
    public ContaCorrente(double saldoEmReais) : base(saldoEmReais) { }

    public virtual double Calcular()
      => SaldoAtualEmReais * 0.015;
}

