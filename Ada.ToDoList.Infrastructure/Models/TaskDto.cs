
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ada.ToDoList.Infrastructure.Models;

public class TaskDto {
    public required int Id {get; set;}

    [Required]
    [DefaultValue(null)] // Só para o Swagger não preencher com um string = Name
    public string Name {get; set;}
}