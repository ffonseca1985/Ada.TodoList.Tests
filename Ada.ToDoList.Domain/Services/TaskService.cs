
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Ada.ToDoList.Domain.Entities;
using Ada.ToDoList.Domain.Repositories;

namespace Ada.ToDoList.Domain.Services;

//Green
public class TaskService {

    private readonly ITaskRepository _taskRepository;

    //Vamos injetar a interface no construtor
    //Para testar o TaskService não precisamos de um repositorio concreto, apenas a interface,
    //o qual iremos mockar.
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task Create(Task task) {

        //Ctrl + k + c = comenta
        //No teste, preciso garantir que o método: _taskRepository.Create seja chamado .
        var taskResult = _taskRepository.Create(task);
        return taskResult;

        // return task;
    }

    public Task GetById(int id) {
        return this._taskRepository.GetById(id);
    }

    public bool Remove(int id) {

        var searchTask = this.GetById(id);
        if (searchTask == null) return false;

        var removed = _taskRepository.Remove(id);
        return removed;
    }

    public Task AddTaskItem(int taskId, List<string> taskItens) {
        return null;
    }
}