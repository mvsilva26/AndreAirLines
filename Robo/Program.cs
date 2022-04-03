using Model;
using File;
using Robo.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            RunAsync().Wait();

        }
        public static async Task RunAsync()
        {
            Console.WriteLine("Extraindo e adicionando dados...");

            var pathFile = @"C:\Users\Michael Silva\Downloads\testes.json";
            await AdicionarVoos(ReadFile.ExtrairDados(pathFile));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarVoos(List<Voo> voos)
        {
            foreach (var voo in voos)
                await AcessoAPIService.CadastrarVoo(voo);
        }
    }
}
