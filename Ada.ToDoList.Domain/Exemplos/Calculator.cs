
using System;

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

    // Resto da divisão de um número

    // Modulo
    public decimal Module(decimal a) {

        //Usando a Lib
        decimal result = Math.Abs(a);

        //Refatorando...
        //Quando a definição
        //decimal definition = Math.Pow(Math.Pow(a, 2), 1/2);

        return result;
    }

    // Raiz => Disparem um exception se o numero for negativo
}