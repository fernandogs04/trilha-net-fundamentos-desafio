namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos;

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
        this.veiculos = new List<string>();
    }

    public void AdicionarVeiculo(string? placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
        {
            throw new ArgumentException("ERRO: Nenhuma placa digitada!");
        }

        veiculos.Add(placa.Trim());
    }

    public decimal RemoverVeiculo(string? placa, int horas)
    {
        if (string.IsNullOrEmpty(placa))
        {
            throw new ArgumentException("ERRO: Nenhuma placa digitada!");
        }

        string? veiculoEncontrado = veiculos.FirstOrDefault(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase));

        if (veiculoEncontrado is null)
        {
            throw new KeyNotFoundException("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        decimal valorTotal = precoInicial + (precoPorHora * horas);

        veiculos.Remove(veiculoEncontrado);

        return valorTotal;
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            throw new InvalidOperationException("Não há veículos estacionados.");
        }

        Console.WriteLine("Os veículos estacionados são:");
        
        foreach (var veiculo in veiculos)
        {
            Console.WriteLine(veiculo);
        }
    }
}
