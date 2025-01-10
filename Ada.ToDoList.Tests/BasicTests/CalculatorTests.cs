
// Precisamos importar o xnit
using Xunit;
using Ada.ToDoList.Domain.Exemplos;

// Padrão:
// Para classe: NomeClasse + Tests
public class CalculatorTests {

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    public void Somar_Given2Numbers_returnValue(decimal a, decimal b, decimal result) {
        //arrange
        Calculator calc = new Calculator();

        //act
        decimal res_som = calc.Somar(a, b);

        //assert
        Assert.Equal(result, res_som);
    }

    [Theory]
    [InlineData(1, 2, 0.5)]
    public void Divir_Given2Numbers_returnValue(decimal a, decimal b, decimal result) {

        //Arange
        Calculator calc = new Calculator();

        //act
        //Usand TDD
        //RED => Não existe test
        decimal res_div = calc.Dividir(a, b);

        //assert
        Assert.Equal(result, res_div);
    }

    [Theory]
    [InlineData(1, 0)]
    public void Dividir_Given2Numbers_ReturnExceptionWhenDenEqualZero(decimal a, decimal b) {
        
        //Arange
        Calculator calc = new Calculator();

        //Assert
        //Test da exception
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(a, b));
    }

    //Padrão Para método
    //Metodo + A condição + Resultado
    // Para testes básicos vamos precisamos informar que é um test
    //   - Para este fim usaremos o Fact
    [Fact] 
    public void String_GivenFrase_NeedContainValue() {

        //Outro Padrão para execução:
        //AAA => 
        // - Arange => Organiza os dados
        string frase = "Unit Test na Caixa";
        string value = "Caixa";

        // - Act => Executar o metodo, funcão etc

        // - Assert
        Assert.Contains(value, frase);
    }

    //Suponha que tenha as palavras "Unit", "Test", "na", "Caixa", eu quero saber 
    //se estas estão na frase "Unit Test na Caixa", como faço?
    [Theory]
    [InlineData("Unit Test na Caixa", "Unit", "Test")]
    [InlineData("Unit Test na Caixa", "na", "Caixa")]
    [InlineData("Unit Test na Caixa", "Unit", "na")]
    public void SetString_GivenFrase_NeedContainValue(string frase, string word1, string word2) {

        //Arrange

        //Act
        string fraseUpper = frase.ToUpper();
        string word1Upper = word1.ToUpper();
        string word2Upper = word2.ToUpper();

        //Assert
        Assert.Contains(word1Upper, fraseUpper);
        Assert.Contains(word2Upper, fraseUpper);
    }
}