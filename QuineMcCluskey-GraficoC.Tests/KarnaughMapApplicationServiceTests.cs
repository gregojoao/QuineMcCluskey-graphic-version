using QuineMcCluskey_GraficoC.Application;
using QuineMcCluskey_GraficoC.Domain.Services;

namespace QuineMcCluskey_GraficoC.Tests;

public class KarnaughMapApplicationServiceTests
{
    [Fact]
    public void CarregarMintermosSoap_ReadsMintermsAndDontCares()
    {
        var mintermos = KarnaughMapApplicationService.CarregarMintermosSoap("0;4;-7;");

        Assert.Equal(3, KarnaughMapApplicationService.numeroVariaveis);
        Assert.Equal(8, mintermos.Count);
        Assert.Equal(1, mintermos[0].Valor);
        Assert.Equal(1, mintermos[4].Valor);
        Assert.Equal(2, mintermos[7].Valor);
    }

    [Fact]
    public void Executa_ReturnsFinalSimplificationLog()
    {
        var mintermos = KarnaughMapApplicationService.CarregarMintermosSoap("0;4;8;12;16;-17;19;20;-21;24;-25;27;28;-29;");
        QuineMcCluskey quine = new QuineMcCluskey(KarnaughMapApplicationService.numeroVariaveis);

        string log = quine.Executa(mintermos);

        Assert.Contains("Resultado Final", log);
        Assert.Contains("___00", log);
        Assert.Contains("1_0_1", log);
    }
}
