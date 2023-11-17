using System;
using Tarifas;
using Clientes;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>();

        string[] linhas = File.ReadAllLines("dados_clientes.txt");

        foreach (string linha in linhas)
        {
            string[] dados = linha.Split('|');

            Cliente cliente = new Cliente(dados[0], dados[1],
              double.Parse(dados[2].Replace(",", ".")),
              double.Parse(dados[3].Replace(",", ".")),
              double.Parse(dados[4].Replace(",", ".")));
            clientes.Add(cliente);
        }

        SistemaTarifas sistema = new SistemaTarifas();
        string pastaDestino = "ArquivosGerados";

        if (!Directory.Exists("ArquivosGerados"))
        {
            Directory.CreateDirectory("ArquivosGerados");
        }

        CultureInfo culture = CultureInfo.CurrentCulture;

        sistema.ClienteProcessado += (cpf, saldo, tarifa) =>
        {
            string nomeArquivo = $"{cpf}.txt";
            string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);
            string conteudoArquivo = $"{saldo.ToString("F2", culture)}|{tarifa.ToString("F2", culture)}";

            File.WriteAllText(caminhoCompleto, conteudoArquivo);

        };

        sistema.CalcularSomatorios(clientes, cpf =>
          Console.WriteLine($"Arquivo gerado para o CPF {cpf}"));


    }
}
