
using Ada.ToDoList.Domain.Repositories;

namespace Ada.ToDoList.Tests.Infrastructure.Repository;

using System.Collections.Generic;
using System.Linq;
using Ada.ToDoList.Domain.Entities;

public class TaskRepositoryMock : ITaskRepository
{
    private List<Task> _tasks = [new Task(1, "Primeira Task")];
    public Task Create(Task task)
    {
        _tasks.Add(task);
        return task;
    }

    public void Dispose() { }

    public Task GetById(int id)
    {
        var task = _tasks.FirstOrDefault(x => x.Id == id);
        return task;
    }

    public bool Remove(int id)
    {
        // var task = GetById(id);
        // var remved = _tasks.Remove(task);

        var qtde = _tasks.RemoveAll(x => x.Id == id);
        return qtde > 0;
    }

    public bool Update(Task task)
    {
        var removed = Remove(task.Id);

        if (!removed) return false;

        this.Create(task);

        return true;
    }
}