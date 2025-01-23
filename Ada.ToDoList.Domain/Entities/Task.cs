
using System;
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

    public void AddTasks(List<string> taskItens)
    {
        //Estudar => FluentValidation
        if (taskItens == null) throw new ArgumentException("TaskItems is null");

        foreach (var item in taskItens) {
            this.TaskItems.Add(new TaskItem(item));
        }
    }

    // public override bool Equals(object? obj)
    // {
    //     if (obj == null) return false; 
    //     var ta1 = (Task)obj;

    //     return this.Id == ta1.Id;
    // }
}

public class Tasas {

    public void Comparar(){

        var t1 = new Task(1, "");
        //var t2 = new Task(1, "");
        var t2 = t1; // Tenho o mesmo endereço de memoria, logo o equals funciona
        var t3 = new Task(1, ""); //Tenho os mesmos valores, porém endereços de memória diferente

        t1.Equals(t2);
    }
}

