

using System;
using Ada.ToDoList.Domain.Repositories;
using Ada.ToDoList.Domain.Services;
using NSubstitute;

namespace Ada.ToDoList.Tests.Domain.Services;

//Vamos guardar aqui todas as variaveis/metodos reutilizaveis e vamos carrega-los uma unica vez.
public class TaskServiceClassFixture : IDisposable
{
    public readonly ITaskRepository TaskRepository; 
    public readonly TaskService TaskService;

    public TaskServiceClassFixture()
    {
        TaskRepository = Substitute.For<ITaskRepository>(); // Mock do Repository
        TaskService = new TaskService(TaskRepository);
    }

    public void Dispose()
    {
        TaskRepository.Dispose();
    }
}