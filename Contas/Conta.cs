namespace Contas;

public abstract class Conta
{
    public virtual double SaldoAtualEmReais { get; protected set; }

    public Conta(double saldoEmReais)
      => SaldoAtualEmReais = saldoEmReais;

}
