
using System.ComponentModel.DataAnnotations;
using Ada.ToDoList.Domain.Services;
using Ada.ToDoList.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ada.ToDoList.Infrastructure.Controllers;

[Route("api/task")] // Rota : https://localhost:{porta}/api/task
[ApiController] // o tipo da controller, ApiController, MvcController
public class TaskController : ControllerBase
{
    readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet()] //Se é um metodo GET no caminho: '/', Se quisermos colocar um id, ficaria [HttpGet("{id}")] e cominho ficaria "/1", por exemplo.
    public ActionResult Get()
    {
        return Ok("OK Task");
    }

    [HttpGet("{id}")] //Se é um metodo GET no caminho: '/', Se quisermos colocar um id, ficaria [HttpGet("{id}")] e cominho ficaria "/1", por exemplo.
    public ActionResult GetById([Required] int? id)
    {
        var search = _taskService.GetById(id!.Value);

        if (search == null) {
            return NotFound($"{id} not found");
        }

        return Ok(search);
    }

    [HttpPost]
    public ActionResult Post([FromBody] TaskDto dto)
    {
        var task = new Domain.Entities.Task(dto.Id, dto.Name);
        var result = _taskService.Create(task);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    //Para executar apertar F5 ou executando o comando:
    //dotnet run --project .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj
}