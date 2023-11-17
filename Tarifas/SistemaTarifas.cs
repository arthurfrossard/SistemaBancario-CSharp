using System;
using Clientes;
using System.IO;
using System.Collections.Generic;

namespace Tarifas;

public class SistemaTarifas
{
    public event Action<string, double, double> ClienteProcessado;

    public void CalcularSomatorios(List<Cliente> clientes, Action<string> callback)
    {
        foreach (Cliente cliente in clientes)
        {
            double saldoTotal = cliente.contaCorrente.SaldoAtualEmReais +
          cliente.contaInternacional.SaldoAtualEmReais +
          cliente.contaCripto.SaldoAtualEmReais;

            double tarifaTotal = cliente.contaCorrente.Calcular() + cliente.contaInternacional.Calcular();

            ClienteProcessado?.Invoke(cliente.CPF, saldoTotal, tarifaTotal);

            callback?.Invoke(cliente.CPF);
        }
    }
}




