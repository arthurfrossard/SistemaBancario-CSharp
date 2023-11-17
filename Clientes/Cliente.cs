using System;
using Contas;

namespace Clientes;

public class Cliente
{
    public string CPF { get; }
    public string Nome { get; }
    public ContaCorrente contaCorrente { get; }
    public ContaInternacional contaInternacional { get; }
    public ContaCripto contaCripto { get; }

    public Cliente(string cpf, string nome, double saldoCorrente, double saldoInternacional, double saldoCripto)
    {
        CPF = cpf;
        Nome = nome;
        contaCorrente = new ContaCorrente(saldoCorrente);
        contaInternacional = new ContaInternacional(saldoInternacional, GerarTaxaCambioAleatoria());
        contaCripto = new ContaCripto(saldoCripto, GerarTaxaCambioAleatoria());
    }

    double GerarTaxaCambioAleatoria()
    {
        Random random = new Random();
        double taxaCambio = random.Next(100, 600) / 100.0;
        return taxaCambio;
    }
}

