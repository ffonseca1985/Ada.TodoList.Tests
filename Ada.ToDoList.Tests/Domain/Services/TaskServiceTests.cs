
using System.Collections.Generic;
using System.Linq;
using Ada.ToDoList.Domain;
using Ada.ToDoList.Domain.Entities;
using Ada.ToDoList.Domain.Repositories;
using Ada.ToDoList.Domain.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Ada.ToDoList.Tests.Domain.Services;

//Passos - Backlog
//1 - Create task

public class TaskServiceTests : IClassFixture<TaskServiceClassFixture> 
{
    public ITaskRepository _taskRepositoryMock;
    public TaskService _taskServiceMock;

    public TaskServiceTests(TaskServiceClassFixture taskServiceClassFixture)
    {
        _taskRepositoryMock = taskServiceClassFixture.TaskRepository;
        _taskServiceMock = taskServiceClassFixture.TaskService;

        //Limpando os "ReceivedCalls"
        _taskRepositoryMock.ClearReceivedCalls();
    }

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
        //var mockTaskRepository = Substitute.For<ITaskRepository>(); // é um mock/simula a classe/interface

        //Eu falei pro mock, como ele deve se comportar??????? Não!!!!
        //Então preciso dizer o que o mock deve fazer!!!
        _taskRepositoryMock.Create(task).Returns(task);  //Definido comportamento

        //Criei o mock
        //ITaskRepository taskRepository = _taskRepositoryMock; 
        //var taskService = new TaskService(taskRepository);

        //Act
        var taskResult = _taskServiceMock.Create(task);      

        //Assert
        Assert.Equivalent(task, taskResult); // Valores das propriedades devem ser igual
        Assert.NotNull(taskResult);

        //Traduzindo:
        //1 - Que o metodo create foi executado
        //2 - E foi executado exatamente 1 vez
        _taskRepositoryMock.Received(1).Create(task);

        //Como testar o repository???
        //Formas:
        //1 - Preciso garantir que o taskRepository foi chamado quando o metodo  taskService.Create foi executado
    }

    //GetById
    [Fact]
    //TDD
    public void GetById_GivenId_ReturnTask() {

        //TDD => RGR
        //Arrange
        var id = 1;
        var name = "Aprender TDD";
        var returnTask = new Task(id, name);

        _taskRepositoryMock.GetById(id).Returns(returnTask); //Disse como o meu repository irá se comportar

        //Act
        var task = _taskServiceMock.GetById(id);

        //Assert
        Assert.Equivalent(task, returnTask); // Todos os valores serão iguais
        Assert.NotNull(task);

        _taskRepositoryMock.Received(1).GetById(id);
    }

    //GetAll

    //DeleteTask => Garantir que existe a task => return bool
    [Fact]
    public void Remove_GivenExistentId_RemoveTask() {

        //TDD => RGR
        //Arange
        var id = 1;
        var name = "Aprender TDD";
        var returnTask = new Task(id, name);
        
        _taskRepositoryMock.GetById(id).Returns(returnTask);
        _taskRepositoryMock.Remove(id).Returns(true);

        //Act
        var removed = _taskServiceMock.Remove(id);

        //Assert
        Assert.True(removed);
        _taskRepositoryMock.Received(1).GetById(id);
        _taskRepositoryMock.Received(1).Remove(id);
    }

    [Fact]
    public void Remove_GivenNotExistentId_NotRemoveTask() {

        //TDD => RGR
        //Arange
        var id = 1;
        var name = "Aprender TDD";
        var returnTask = new Task(id, name);
        
        _taskRepositoryMock.GetById(id).ReturnsNull();
        //_taskRepositoryMock.Remove(id).Returns(true);

        //Act
        var removed = _taskServiceMock.Remove(id);

        //Assert
        Assert.False(removed);
        _taskRepositoryMock.Received(1).GetById(id);

        // Como não é para remover, logo, não deve executar o método TaskRepository.Remove
        _taskRepositoryMock.Received(0).Remove(id); 
    }

    //AddTaskItem (taskId, description) : bool/Exception
       //Props TaskItem:
           // -  Id : int/string
           // - Description: string
           // - Status: TaskStatus(enum) => NotStarted

    [Fact]
    public void  AddTaskItem_GivenTaskId_AddOneTaskItem(){

     //TDD > RGR   
     //Arange
     int taskId = 1;
     List<string> taskItens = ["Estudar BDD", "Estudar DDD", "Estudar TDD"];

     Task task = new Task(taskId, "Estudar");
     //task.TaskItems = [];

    // comportamentos
    _taskRepositoryMock.GetById(taskId).Returns(task);
    _taskRepositoryMock.Update(task).Returns(true);

     //Act
     ExecutionResult<Task> executionResult = _taskServiceMock.AddTaskItem(taskId, taskItens);
     Task taskResult = executionResult.Data!; // !porque ele deve existir!! 

     //Assert
     Assert.NotNull(taskResult);
     Assert.True(executionResult.Success);

     Assert.True(taskResult.TaskItems.Count == taskItens.Count);
     Assert.True(taskResult.TaskItems.All(x => x.Status == TaskStatus.NotStarted));
     
    _taskRepositoryMock.Received(1).Update(task); // => Precisamos, antes adicionar um comportamento
    _taskRepositoryMock.Received(1).GetById(taskId);

    //Criar as propriedades de TaskItem!!!

     //Todos os itens/description estejam no TaskItnes
     //Para validar, vamos usar linq (c# => System.Linq)
     Assert.True(taskResult.TaskItems.All((TaskItem x) => taskItens.Contains(x.Description)));
     Assert.True(taskItens.All(x => taskResult.TaskItems.Select(x => x.Description).Contains(x)));
    }      
}