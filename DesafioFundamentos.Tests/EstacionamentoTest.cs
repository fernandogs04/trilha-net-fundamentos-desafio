using DesafioFundamentos.Models;

namespace DesafioFundamentos.Tests;

public class EstacionamentoTest
{
    private readonly decimal precoInicial = 2.00m;
    private readonly decimal precoPorHora = 1.00m;

    [Fact]
    public void Construtor_DeveInicializarCorretamente()
    {
        // Arrange
        Estacionamento estacionamento;
        
        // Act
        estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Assert
        Assert.NotNull(estacionamento);
    }

    [Fact]
    public void AdicionarVeiculo_ComPlacaValida_DeveAdicionarVeiculo()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "ABC-1234";

        // Act & Assert
        estacionamento.AdicionarVeiculo(placa);
    }

    [Fact]
    public void AdicionarVeiculo_ComPlacaNula_DeveLancarArgumentException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => estacionamento.AdicionarVeiculo(null));

        // Assert
        Assert.Equal("ERRO: Nenhuma placa digitada!", exception.Message);
    }

    [Fact]
    public void AdicionarVeiculo_ComPlacaVazia_DeveLancarArgumentException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => estacionamento.AdicionarVeiculo(""));

        // Assert
        Assert.Equal("ERRO: Nenhuma placa digitada!", exception.Message);
    }

    [Fact]
    public void AdicionarVeiculo_ComPlacaEspacosEmBranco_DeveLancarArgumentException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => estacionamento.AdicionarVeiculo("   "));

        // Assert
        Assert.Equal("ERRO: Nenhuma placa digitada!", exception.Message);
    }

    [Fact]
    public void RemoverVeiculo_ComPlacaNula_DeveLancarArgumentException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => estacionamento.RemoverVeiculo(null, 1));

        // Assert
        Assert.Equal("ERRO: Nenhuma placa digitada!", exception.Message);
    }

    [Fact]
    public void RemoverVeiculo_ComPlacaVazia_DeveLancarArgumentException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => estacionamento.RemoverVeiculo("", 1));

        // Assert
        Assert.Equal("ERRO: Nenhuma placa digitada!", exception.Message);
    }

    [Fact]
    public void RemoverVeiculo_ComPlacaInexistente_DeveLancarKeyNotFoundException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<KeyNotFoundException>(() => estacionamento.RemoverVeiculo("XYZ-9999", 1));

        // Assert
        Assert.Equal("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente", exception.Message);
    }

    [Fact]
    public void ListarVeiculos_ComEstacionamentoVazio_DeveLancarInvalidOperationException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => estacionamento.ListarVeiculos());

        // Assert
        Assert.Equal("Não há veículos estacionados.", exception.Message);
    }

    [Fact]
    public void ListarVeiculos_ComVeiculosEstacionados_DeveExecutarSemExcecao()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        estacionamento.AdicionarVeiculo("ABC-1234");
        estacionamento.AdicionarVeiculo("DEF-5678");

        // Act & Assert
        estacionamento.ListarVeiculos();
    }

    [Fact]
    public void AdicionarVeiculo_PlacasComCasosDiferentes_DevePermitirAdicionar()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act & Assert
        estacionamento.AdicionarVeiculo("abc-1234");
        estacionamento.AdicionarVeiculo("ABC-1234");
        estacionamento.AdicionarVeiculo("Abc-1234");
    }

    [Fact]
    public void AdicionarVeiculo_ComEspacosNaPlaca_DeveRemoverEspacos()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Act & Assert
        estacionamento.AdicionarVeiculo("  ABC-1234  ");
    }

    [Fact]
    public void RemoverVeiculo_ComVeiculoExistente_DeveCalcularPrecoCorretamente()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "ABC-1234";
        var horas = 3;
        estacionamento.AdicionarVeiculo(placa);

        // Act
        var valorTotal = estacionamento.RemoverVeiculo(placa, horas);

        // Assert
        var valorEsperado = precoInicial + (precoPorHora * horas); // 2.00 + (1.00 * 3) = 5.00
        Assert.Equal(valorEsperado, valorTotal);
    }

    [Fact]
    public void RemoverVeiculo_ComZeroHoras_DeveRetornarApenasPrecoInicial()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "ABC-1234";
        estacionamento.AdicionarVeiculo(placa);

        // Act
        var valorTotal = estacionamento.RemoverVeiculo(placa, 0);

        // Assert
        Assert.Equal(precoInicial, valorTotal);
    }

    [Fact]
    public void RemoverVeiculo_ComMuitasHoras_DeveCalcularCorretamente()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "ABC-1234";
        var horas = 24;
        estacionamento.AdicionarVeiculo(placa);

        // Act
        var valorTotal = estacionamento.RemoverVeiculo(placa, horas);

        // Assert
        var valorEsperado = precoInicial + (precoPorHora * horas); // 2.00 + (1.00 * 24) = 26.00
        Assert.Equal(valorEsperado, valorTotal);
    }

    [Fact]
    public void RemoverVeiculo_DeveRemoverVeiculoDaLista()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "ABC-1234";
        estacionamento.AdicionarVeiculo(placa);

        // Act
        estacionamento.RemoverVeiculo(placa, 1);
        var exception = Assert.Throws<KeyNotFoundException>(() => estacionamento.RemoverVeiculo(placa, 1));

        // Assert
        Assert.Equal("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente", exception.Message);
    }

    [Fact]
    public void RemoverVeiculo_ComPlacaDiferentCase_DeveEncontrarVeiculo()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        estacionamento.AdicionarVeiculo("abc-1234");

        // Act
        var valorTotal = estacionamento.RemoverVeiculo("ABC-1234", 2);

        // Assert
        var valorEsperado = precoInicial + (precoPorHora * 2);
        Assert.Equal(valorEsperado, valorTotal);
    }

    [Fact]
    public void RemoverVeiculo_ComPlacaComEspacos_DeveLancarKeyNotFoundException()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        estacionamento.AdicionarVeiculo("ABC-1234");

        // Act
        var excepQUtion = Assert.Throws<KeyNotFoundException>(() => estacionamento.RemoverVeiculo("  ABC-1234  ", 1));

        // Assert
        Assert.Equal("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente", exception.Message);
    }

    [Theory]
    [InlineData(1, 3.00)]
    [InlineData(2, 4.00)]
    [InlineData(5, 7.00)]
    [InlineData(10, 12.00)]
    public void RemoverVeiculo_ComDiferentesHoras_DeveCalcularCorretamente(int horas, decimal valorEsperado)
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa = "TEST-001";
        estacionamento.AdicionarVeiculo(placa);

        // Act
        var valorTotal = estacionamento.RemoverVeiculo(placa, horas);

        // Assert
        Assert.Equal(valorEsperado, valorTotal);
    }

    [Fact]
    public void Estacionamento_ComPrecosDiferentes_DeveCalcularCorretamente()
    {
        // Arrange
        var precoInicialCustom = 5.00m;
        var precoPorHoraCustom = 2.50m;
        var estacionamento = new Estacionamento(precoInicialCustom, precoPorHoraCustom);
        var placa = "ABC-1234";
        var horas = 4;
        estacionamento.AdicionarVeiculo(placa);

        // Act
        var valorTotal = estacionamento.RemoverVeiculo(placa, horas);

        // Assert
        var valorEsperado = precoInicialCustom + (precoPorHoraCustom * horas); // 5.00 + (2.50 * 4) = 15.00
        Assert.Equal(valorEsperado, valorTotal);
    }

    [Fact]
    public void ListarVeiculos_ComUmVeiculo_DeveExecutarSemExcecao()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        estacionamento.AdicionarVeiculo("ABC-1234");

        // Act & Assert
        estacionamento.ListarVeiculos();
    }

    [Fact]
    public void FluxoCompleto_AdicionarListarRemover_DeveExecutarCorretamente()
    {
        // Arrange
        var estacionamento = new Estacionamento(precoInicial, precoPorHora);
        var placa1 = "ABC-1234";
        var placa2 = "DEF-5678";

        // Act & Assert
        // Adicionar veículos
        estacionamento.AdicionarVeiculo(placa1);
        estacionamento.AdicionarVeiculo(placa2);

        // Listar veículos
        estacionamento.ListarVeiculos();

        // Remover um veículo
        var valor = estacionamento.RemoverVeiculo(placa1, 2);
        Assert.Equal(4.00m, valor);

        // Listar novamente (ainda deve ter um veículo)
        estacionamento.ListarVeiculos();

        // Remover o último veículo
        estacionamento.RemoverVeiculo(placa2, 1);

        // Tentar listar com estacionamento vazio deve lançar exceção
        var exception = Assert.Throws<InvalidOperationException>(() => estacionamento.ListarVeiculos());
        Assert.Equal("Não há veículos estacionados.", exception.Message);
    }
}
