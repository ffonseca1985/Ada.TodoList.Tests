
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
}