using DesafioFundamentos.Models;

namespace DesafioFundamentos;

class Program
{
    static void Main(string[] args)
    {
        // Coloca o encoding para UTF8 para exibir acentuação
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
        Console.WriteLine("Digite o preço inicial:");
        decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

        // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    string? placa = Console.ReadLine();

                    try
                    {
                        estacionamento.AdicionarVeiculo(placa);
                        Console.WriteLine("Veículo cadastrado com sucesso!");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Digite a placa do veículo para remover:");
                    string? placa = Console.ReadLine();

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        decimal valorTotal = estacionamento.RemoverVeiculo(placa, horas);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                case "3":
                {
                    try
                    {
                        estacionamento.ListarVeiculos();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                case "4":
                {
                    exibirMenu = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Opção inválida");
                    break;
                }
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");

    }
}
