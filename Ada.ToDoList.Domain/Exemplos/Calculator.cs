
namespace Ada.ToDoList.Domain.Exemplos;

//Vamos Fazer o codigo e depois Testar
public class Calculator {

    //vamos criar um método chamado somar
    public decimal Somar(decimal a, decimal b) {
        return a + b;
    }

    public decimal Dividir(decimal a, decimal b) {
        //2 - Green => Faz o teste para passar, esquece os detalhes.

        //3 - Refactory
        if (b == 0) {
            throw new DivideByZeroException("O denomindor é igual a zero!!!");
        }

        return a / b;
    }

    // Multiplicacao

    // Subtracao

    // Resto da divisão de um numero

    // Modulo

    // Raiz => Disparem um exception se o numero for negativo
}