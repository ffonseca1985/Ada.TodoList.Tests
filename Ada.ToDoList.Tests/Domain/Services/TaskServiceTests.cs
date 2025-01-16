
using Ada.ToDoList.Domain.Entities;
using Ada.ToDoList.Domain.Repositories;
using Ada.ToDoList.Domain.Services;
using NSubstitute;

namespace Ada.ToDoList.Tests.Domain.Services;

//Passos - Backlog
//1 - Create task

public class TaskServiceTests
{
    //Commands: 
    //Ctrl + a = Seleciona tudo.
    //Ctrl + k + f = Formata o arquivo/classe.
    //Ctrl + . = Intellicense

    [Fact]
    public void Create_GivenTask_InsertToRepository()
    {

        //Arrange

        //Build Task
        int id = 1;
        string taskName = "Estudar TDD";
        Task task = new Task(id, taskName);

        //Para construir o TaskService, o que precisamos???? Qual depencia???
        //Para resolver o problema de estar nulo, vamos criar um mock
        //O que é um mock? é um objeto que simula a instancia da classe, neste caso o ITaskRepository, 

        //O For é o metodo usado para criar a instancia (simualada/mackada)
        var mockTaskRepository = Substitute.For<ITaskRepository>(); // é um mock/simula a classe/interface

        //Eu falei pro mock, como ele deve se comportar??????? Não!!!!
        //Então preciso dizer o que o mock deve fazer!!!
        mockTaskRepository.Create(task).Returns(task);  //Definido comportamento

        //Criei o mock
        ITaskRepository taskRepository = mockTaskRepository; 
        var taskService = new TaskService(taskRepository);

        //Act
        var taskResult = taskService.Create(task);      

        //Assert
        Assert.Equivalent(task, taskResult); // Valores das propriedades devem ser igual
        Assert.NotNull(taskResult);

        //Traduzindo:
        //1 - Que o metodo create foi executado
        //2 - E foi executado exatamente 1 vez
        mockTaskRepository.Received(1).Create(task);

        //Como testar o repository???
        //Formas:
        //1 - Preciso garantir que o taskRepository foi chamado quando o metodo  taskService.Create foi executado
    }

    //GetById

    //GetAll

    //DeleteTask => Garantir que existe a task

    //AddTaskItem (IdTask, TasKITem) : bool/Exception
       //Props TaskItem:
           // -  Id : int/string
           // - Description: string
           // - Status: TaskStatus(enum) => NotStarted
}