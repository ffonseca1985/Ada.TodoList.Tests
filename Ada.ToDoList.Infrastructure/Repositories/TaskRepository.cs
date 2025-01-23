
using Ada.ToDoList.Domain.Repositories;

namespace Ada.ToDoList.Infrastructure.Repositories;

public class TasKRepository : ITaskRepository
{
    private List<Domain.Entities.Task> _tasks = new();
    public Domain.Entities.Task Create(Domain.Entities.Task task)
    {
        _tasks.Add(task);
        return task;
    }

    public void Dispose() { }

    public Domain.Entities.Task GetById(int id)
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

    public bool Update(Domain.Entities.Task task)
    {
        var removed = Remove(task.Id);

        if (!removed) return false;

        this.Create(task);        

        return true;
    }
}