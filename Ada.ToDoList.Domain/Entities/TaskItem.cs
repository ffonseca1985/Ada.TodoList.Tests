using System;

namespace Ada.ToDoList.Domain.Entities;

public class TaskItem {
    
    public TaskItem(string description)
    {
        Id = Guid.NewGuid().ToString();
        Status = TaskStatus.NotStarted;

        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description null or White space");
        Description = description;
    }
    
    public string Id { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
}