
using Microsoft.AspNetCore.Mvc;

namespace Ada.ToDoList.Infrastructure.Controllers;

[Route("api/task")] // Rota : https://localhost:{porta}/api/task
[ApiController] // o tipo da controller, ApiController, MvcController
public class TaskController : ControllerBase {

    [HttpGet()] //Se é um metodo GET no caminho: '/', Se quisermos colocar um id, ficaria [HttpGet("{id}")] e cominho ficaria "/1", por exemplo.
    public ActionResult Get() {
        return Ok("OK Task");
    }

    //Para executar apertar F5 ou executando o comando:
    //dotnet run --project .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj
}