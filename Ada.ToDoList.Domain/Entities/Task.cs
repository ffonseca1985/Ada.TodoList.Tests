
using System.Collections.Generic;

namespace Ada.ToDoList.Domain.Entities;

public class Task {
    public Task(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.Status = TaskStatus.NotStarted;
        //this.TaskItems = new List<TaskItem>();
        this.TaskItems = [];
    }

    public int Id { get; set; }
    public string Name {get; set;}
    public TaskStatus Status {get; set;} // Valor default é o enum que está no indice 0
    public List<TaskItem> TaskItems { get; set; } // SE não atribuirmos valor a lista ela fica nula
    public List<TaskItem> GetTaskItems() => this.TaskItems;
}