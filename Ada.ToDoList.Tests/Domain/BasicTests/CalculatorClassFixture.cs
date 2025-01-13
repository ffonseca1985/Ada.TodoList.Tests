

//ClassFixture => são classes que contém objetos reutilizáveis.
//IDisposable é opcional
using System;
using Ada.ToDoList.Domain.Exemplos;

public class CalculatorClassFixture : IDisposable
{
    public Calculator Calculator { get; set; }
    public static int Valor {get; set;} = 0;

    //Depois de criado o obj CalculatorClassFixture ele não irá cria-lo novamente 
    //Ele irá reutilizá-lo
    public CalculatorClassFixture()
    {
        Calculator = new Calculator();
        Valor += 1;
    }

    //Lembre-se que quando usamos testes, "alguns" objetos precisam ser deletados/fechados/finalizados
    public void Dispose()
    {
        Calculator = null;
        //throw new NotImplementedException();
    }
}