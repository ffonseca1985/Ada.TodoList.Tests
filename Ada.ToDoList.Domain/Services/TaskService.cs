
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

    public ExecutionResult<Task> AddTaskItem(int taskId, List<string> taskItens) {

        // Temos que fazer um monte de validaçao!!!
        //Quais???
        //Se task existe
        //Se o taskId é valido
        //Se o Update funcionou
        //Se o não funcionou

        //Temos duas saidas:
        //1 - Lancar exception para cada validação invalida;
        //2 - Retornar um objeto que informe tudo o que ocorreu

        if (taskId <= default(int)) {
            //Lancar exception ou retornar um objeto que me dê toda a informação da execução do Metodo;
            return ExecutionResult<Task>.CreateFailure("TaskId invalid");
        }

        if (taskItens == null || taskItens.Any() == false) {
            return ExecutionResult<Task>.CreateFailure("TaskItens cannot be null or empty");
        }

        try {

            //Buscar a tarefa pelo Id
            var task = _taskRepository.GetById(taskId);

            //Se não achar, retorna uma falha.
            if (task == null) return ExecutionResult<Task>.CreateFailure($"Task {taskId} not found");

            //caso, contrario
            task.AddTasks(taskItens);

            //Atualizar a Task
            var updated = _taskRepository.Update(task);

            //Validamos se foi moduficado no banco
            if (updated == false) {
                return ExecutionResult<Task>.CreateFailure($"Failed to update the task {taskId}.");
            }

            return ExecutionResult<Task>.CreateSuccess(task);
        } 
        catch (Exception ex) {
          return ExecutionResult<Task>.CreateFailure(ex.Message); 
        }
    }
}