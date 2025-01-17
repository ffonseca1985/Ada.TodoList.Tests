
using System;
using Ada.ToDoList.Domain.Entities;

namespace Ada.ToDoList.Domain.Repositories;

//No teste vamos mockar a interface
//A interf ITaskRepository (Pertence a camada de Domain)
//A sua implementacao será na camada de Infra.
public interface ITaskRepository : IDisposable {
   Task Create(Task task);
   Task GetById(int id);
   bool Remove(int id);
}